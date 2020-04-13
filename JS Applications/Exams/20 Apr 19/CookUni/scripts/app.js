import {get, post, put, del} from "./requester.js";

const categories = {
    "Vegetables and legumes/beans" : "https://cdn.pixabay.com/photo/2017/10/09/19/29/eat-2834549__340.jpg",
    "Fruits" : "https://cdn.pixabay.com/photo/2017/06/02/18/24/fruit-2367029__340.jpg",
    "Grain Food" : "https://cdn.pixabay.com/photo/2014/12/11/02/55/corn-syrup-563796__340.jpg",
    "Milk, cheese, eggs and alternatives" : "https://image.shutterstock.com/image-photo/assorted-dairy-products-milk-yogurt-260nw-530162824.jpg",
    "Lean meats and poultry, fish and alternatives" : "https://t3.ftcdn.net/jpg/01/18/84/52/240_F_118845283_n9uWnb81tg8cG7Rf9y3McWT1DT1ZKTDx.jpg"
};

(() => {
    const app = Sammy('#rooter', function () {
      this.use('Handlebars', 'hbs');

      this.get('#/home', function(ctx){
        setHeaderInfo(ctx);

        if (ctx.isAuth) {
            get("appdata", "recipes", "Kinvey")
                .then((recipes) => {

                    ctx.recipes = recipes;
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
            firstName,
            lastName,
            username,
            password,
            repeatPassword
        } = ctx.params;

        if (firstName && lastName && username && password && password === repeatPassword) {
            post("user", "", {
                    firstName,
                    lastName,
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
            .partial("../views/recipe/create.hbs");
    });

    this.post("#/create", function (ctx) {
        const {
            meal,
            ingredients,
            prepMethod,
            description,
            foodImageURL,
            category
        } = ctx.params;

        if (meal && prepMethod && ingredients && description && foodImageURL && category) {
            post("appdata", "recipes", {
                meal,
                prepMethod,
                ingredients : ingredients.split(" "),
                description,
                foodImageURL,
                category,
                likesCounter : 0,
                categoryImageURL : categories[category]
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

        get("appdata", `recipes/${id}`, "Kinvey")
            .then((recipe) => {
                ctx.isCreator = sessionStorage.getItem("userId") === recipe._acl.creator;
                ctx.recipe = recipe;

                this.loadPartials(getPartials())
                    .partial("../views/recipe/details.hbs");
            })
            .catch(console.error);
    });

    this.get("#/delete/:id", function(ctx){
        const id = ctx.params.id;
        setHeaderInfo(ctx);

        del("appdata", `recipes/${id}`, "Kinvey")
        .then(()=>{
            ctx.redirect("#/home");

        })
        .catch(console.error);
    });

    this.get("#/edit/:id", function (ctx) {
        const id = ctx.params.id;
        setHeaderInfo(ctx);

        get("appdata", `recipes/${id}`, "Kinvey")
            .then((recipe) => {
               recipe.ingredients = recipe.ingredients.join(" ");
                ctx.recipe = recipe;

                this.loadPartials(getPartials())
                    .partial("../views/recipe/edit.hbs");
            })
            .catch(console.error);
    });

    this.post("#/edit/:id", function (ctx) {
        const id = ctx.params.id;
        setHeaderInfo(ctx);

        const {
            meal,
            ingredients,
            prepMethod,
            description,
            foodImageURL,
            category
        } = ctx.params;

        put("appdata", `recipes/${id}`, {
            meal,
            ingredients : ingredients.split(" "),
            prepMethod,
            description,
            foodImageURL,
            category,
            categoryImageURL : categories[category],
            likesCounter : 0
            },
                "Kinvey")
            .then(() => {
                ctx.redirect("#/home");
            })
            .catch(console.error);
    });

    this.get("#/like/:id", async function (ctx) {
        const id = ctx.params.id;
        setHeaderInfo(ctx);

        let recipe = await get("appdata", `recipes/${id}`, "Kinvey");

        put("appdata", `recipes/${id}`, {
            meal: recipe.meal,
            ingredients: recipe.ingredients,
            prepMethod: recipe.prepMethod,
            description: recipe.description,
            category: recipe.category,
            foodImageURL : recipe.foodImageURL,
            categoryImageURL : recipe.categoryImageURL,
            likesCounter: Number(recipe.likesCounter) + 1
            }, "Kinvey")
            .then(() => {
                ctx.redirect("#/home");
            })
            .catch(console.error);
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
        sessionStorage.setItem("names", `${userInfo.firstName} ${userInfo.lastName}`);
        sessionStorage.setItem("userId", userInfo._id);
    }

    function setHeaderInfo(ctx) {
        ctx.isAuth = sessionStorage.getItem("authtoken") !== null;
        ctx.username = sessionStorage.getItem("username");
        ctx.names = sessionStorage.getItem("names");
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