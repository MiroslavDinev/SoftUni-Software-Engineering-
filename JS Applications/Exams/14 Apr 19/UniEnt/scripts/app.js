import {get, post, put, del} from "./requester.js";

(() => {
    const app = Sammy('body', function () {
      this.use('Handlebars', 'hbs');

      this.get('#/home', function(ctx){
        setHeaderInfo(ctx);
            
        if(ctx.isAuth){
            get("appdata", "events", "Kinvey")
            .then((events)=>{
                events.sort((a,b)=> b.peopleInterestedIn - a.peopleInterestedIn);
                ctx.events = events;
                this.loadPartials(getPartials())
                .partial("../views/home.hbs");
            })
            .catch(console.error);
        }
        else{
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
                    ctx.redirect("#/home");
                })
                .catch(console.error);
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
                    ctx.redirect("#/home");
                })
                .catch(console.error);
        }
    });

    this.get("#/logout", function (ctx) {
        post("user", "_logout", {}, "Kinvey")
            .then(() => {
                sessionStorage.clear();
                ctx.redirect("#/home");
            })
            .catch(console.error);
    });

    this.get("#/create", function (ctx) {
        setHeaderInfo(ctx);
        this.loadPartials(getPartials())
            .partial("../views/event/create.hbs");
    });

    this.post("#/create", function (ctx) {
        const {
            name,
            dateTime,
            description,
            imageURL
        } = ctx.params;

        let username = sessionStorage.getItem("username");

        if (name && dateTime && description && imageURL) {
            post("appdata", "events", {
                name,
                dateTime,
                description,
                imageURL,
                peopleInterestedIn : 0,
                organizer : username
                },
                    "Kinvey")
                .then(() => {
                    ctx.redirect("#/home");
                })
                .catch(console.error);
        }
    });

    this.get("#/details/:id", function (ctx) {
        const id = ctx.params.id;
        setHeaderInfo(ctx);

        get("appdata", `events/${id}`, "Kinvey")
            .then((event) => {
                ctx.isCreator = sessionStorage.getItem("username") === event.organizer;
                ctx.event = event;

                this.loadPartials(getPartials())
                    .partial("../views/event/details.hbs");
            })
            .catch(console.error);
    });

    this.get("#/delete/:id", function(ctx){
        const id = ctx.params.id;
        setHeaderInfo(ctx);

        del("appdata", `events/${id}`, "Kinvey")
        .then(()=>{
            ctx.redirect("#/home");
        })
        .catch(console.error);
    });

    this.get("#/edit/:id", function (ctx) {
        const id = ctx.params.id;
        setHeaderInfo(ctx);

        get("appdata", `events/${id}`, "Kinvey")
            .then((event) => {
                ctx.event = event;

                this.loadPartials(getPartials())
                    .partial("../views/event/edit.hbs");
            })
            .catch(console.error);
    });

    this.post("#/edit/:id", function (ctx) {
        const id = ctx.params.id;
        setHeaderInfo(ctx);

        const {
            name,
            dateTime,
            description,
            imageURL,
            organizer,
            peopleInterestedIn
        } = ctx.params;

        put("appdata", `events/${id}`, {
            name,
            dateTime,
            description,
            imageURL,
            organizer,
            peopleInterestedIn
            },
                "Kinvey")
            .then(() => {
                ctx.redirect("#/home");
            })
            .catch(console.error);
    });

    this.get("#/join/:id", async function (ctx) {
        const id = ctx.params.id;
        setHeaderInfo(ctx);

        let event = await get("appdata", `events/${id}`, "Kinvey");

        put("appdata", `events/${id}`, {
                name: event.name,
                dateTime: event.dateTime,
                description: event.description,
                imageURL: event.imageURL,
                organizer: event.organizer,
                peopleInterestedIn: Number(event.peopleInterestedIn) + 1
            }, "Kinvey")
            .then(() => {
                ctx.redirect("#/home");
            })
            .catch(console.error);
    });

    this.get("#/profile", async function (ctx) {
        setHeaderInfo(ctx);

        let events = await get("appdata", "events", "Kinvey");
        let myEvents = events.filter(e => e.organizer === ctx.username);
        ctx.myEvents = myEvents;
        ctx.countEvents = myEvents.length;

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

    // function successMsg(message) {
    //     const successBox = document.getElementById("successBox");
    //     successBox.style.display = "block";
    //     successBox.textContent = message;
    //     setTimeout(() => {
    //         errorBox.style.display = 'none';
    //     }, 5000);
    // }

    // function displayError(message) {
    //     const errorBox = document.getElementById("errorBox");
    //     errorBox.style.display = "block";
    //     errorBox.textContent = message;
    //     setTimeout(() => {
    //         errorBox.style.display = 'none';
    //     }, 2000);
    // }

    });
    app.run('#/home');
  })();