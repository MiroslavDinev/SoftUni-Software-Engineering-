import {get, post, put, del} from "./requester.js";

(() => {
    const app = Sammy('body', function () {
      this.use('Handlebars', 'hbs');

      this.get('#/home', function(ctx){
        setHeaderInfo(ctx);

        if (ctx.isAuth) {
            get("appdata", "treks", "Kinvey")
                .then((treks) => {
                    treks.sort((a,b)=>b.likes-a.likes);
                    ctx.treks = treks;
                    this.loadPartials(getPartials())
                        .partial("../views/home.hbs");
                })
                .catch(console.error);
        } else {
            this.loadPartials(getPartials())
                .partial("../views/guestHome.hbs");
        }
      });

      this.get("#/register", function (ctx) {
        this.loadPartials(getPartials())
            .partial("../views/auth/register.hbs");
    });

    this.post("#/register", function (ctx) {
        const {
            username,
            password,
            rePassword
        } = ctx.params;

        if (username.length>=3 && password.length>=6 && password === rePassword) {
            post("user", "", {
                    username,
                    password
                }, "Basic")
                .then((userInfo) => {
                    saveAuthInfo(userInfo);
                    successMsg("Successfully registered user.");
                    ctx.redirect("#/home");
                })
                .catch(console.error);
        }
        else{
            displayError("Invalid credentials. Please retry your request with correct credentials.");
        }
    });

    this.get("#/login", function (ctx) {
        this.loadPartials(getPartials())
            .partial("../views/auth/login.hbs");
    });

    this.post("#/login", function (ctx) {
        const {
            username,
            password
        } = ctx.params;

        if (username && password) {
            post("user", "login", {
                    username,
                    password
                }, "Basic")
                .then((userInfo) => {
                    saveAuthInfo(userInfo);
                    successMsg("Successfully logged user.");
                    ctx.redirect("#/home");
                })
                .catch(console.error);
        }
        else{
            displayError("Invalid credentials. Please retry your request with correct credentials.");
        }
    });

    this.get("#/logout", function (ctx) {
        post("user", "_logout", {}, "Kinvey")
            .then(() => {
                sessionStorage.clear();
                successMsg("Logout successful.");
                ctx.redirect("#/home");
            })
            .catch(console.error);
    });

    this.get("#/create", function (ctx) {
        setHeaderInfo(ctx);
        this.loadPartials(getPartials())
            .partial("../views/trek/create.hbs");
    });

    this.post("#/create", function (ctx) {
        const {
            location,
            dateTime,
            description,
            imageURL
        } = ctx.params;

        let username = sessionStorage.getItem("username");

        if (location && dateTime && description && imageURL) {
            post("appdata", "treks", {
                name : location,
                dateTime,
                description,
                imageURL,
                likes : 0,
                organizer : username
                },
                    "Kinvey")
                .then(() => {
                    successMsg("Trek created successfully.");
                    ctx.redirect("#/home");
                })
                .catch(console.error);
        }
        else{
            displayError("Invalid input.");
        }
    });

    this.get("#/details/:id", function (ctx) {
        const id = ctx.params.id;
        setHeaderInfo(ctx);

        get("appdata", `treks/${id}`, "Kinvey")
            .then((trek) => {
                ctx.isOrganizer = sessionStorage.getItem("username") === trek.organizer;
                ctx.trek = trek;

                this.loadPartials(getPartials())
                    .partial("../views/trek/details.hbs");
            })
            .catch(console.error);
    });

    this.get("#/delete/:id", function(ctx){
        const id = ctx.params.id;
        setHeaderInfo(ctx);

        del("appdata", `treks/${id}`, "Kinvey")
        .then(()=>{
            successMsg("Trek closed successfully.");
            ctx.redirect("#/home");
        })
        .catch(console.error);
    });

    this.get("#/edit/:id", function(ctx){
        const id = ctx.params.id;
        setHeaderInfo(ctx);

        get("appdata", `treks/${id}`, "Kinvey")
        .then((trek)=>{

            ctx.trek = trek;

            this.loadPartials (getPartials())
            .partial("../views/trek/edit.hbs");
        })
        .catch(console.error);
    });

    this.post("#/edit/:id", function(ctx){
        const id = ctx.params.id;
        setHeaderInfo(ctx);

        const {location, dateTime, description, imageURL, organizer, likes} = ctx.params;

        put("appdata", `treks/${id}`, 
            {name : location, 
            dateTime,  
            description, 
            imageURL, 
            organizer,
            likes}, 
            "Kinvey")
        .then(()=>{
            successMsg("Trek edited successfully.");
            ctx.redirect("#/home");
        })
        .catch(console.error);
    });

    this.get("#/like/:id", async function (ctx) {
        const id = ctx.params.id;
        setHeaderInfo(ctx);

        let trek = await get("appdata", `treks/${id}`, "Kinvey");

        put("appdata", `treks/${id}`, {
                name: trek.name,
                dateTime: trek.dateTime,
                description: trek.description,
                imageURL: trek.imageURL,
                organizer: trek.organizer,
                likes: Number(trek.likes) + 1
            }, "Kinvey")
            .then(() => {
                successMsg("Trek liked successfully.");
                ctx.redirect("#/home");
            })
            .catch(console.error);
    });

    this.get("#/profile", async function (ctx) {
        setHeaderInfo(ctx);

        let treks = await get("appdata", "treks", "Kinvey");
        let myTreks = treks.filter(t => t.organizer === ctx.username);
        ctx.myTreks = myTreks;
        ctx.countTreks = myTreks.length;

        this.loadPartials(getPartials())
            .partial("../views/auth/profile.hbs");
    });

    function getPartials() {
        return {
            header: "../views/common/header.hbs",
            footer: "../views/common/footer.hbs"
        };
    }

    function saveAuthInfo(userInfo) {
        sessionStorage.setItem("authtoken", userInfo._kmd.authtoken);
        sessionStorage.setItem("username", `${userInfo.username}`);
        sessionStorage.setItem("userId", userInfo._id);
    }

    function setHeaderInfo(ctx) {
        ctx.isAuth = sessionStorage.getItem("authtoken") !== null;
        ctx.username = sessionStorage.getItem("username");
    }

    function successMsg(message) {
        const successBox = document.getElementById("successBox");
        successBox.style.display = "block";
        successBox.textContent = message;
        setTimeout(() => {
            errorBox.style.display = 'none';
        }, 5000);
    }

    function displayError(message) {
        const errorBox = document.getElementById("errorBox");
        errorBox.style.display = "block";
        errorBox.textContent = message;
        setTimeout(() => {
            errorBox.style.display = 'none';
        }, 2000);
    }
  
    });
    app.run('#/home');
  })();