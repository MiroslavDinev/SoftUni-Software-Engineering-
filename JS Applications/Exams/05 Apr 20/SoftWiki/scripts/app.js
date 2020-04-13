import {get, post, put, del} from "./requester.js";

(() => {
    const app = Sammy('#root', function () {
      this.use('Handlebars', 'hbs');

      this.get('#/home', function(ctx){
        setHeaderInfo(ctx);

        let JSArticles = [];
        let CSharpArticles = [];
        let JavaArticles = [];
        let PythonArticles = [];

        if (ctx.isAuth) {
            get("appdata", "articles", "Kinvey")
                .then((articles) => {
                    articles.sort((a,b)=>(b.title).localeCompare(a.title));

                    for (let i = 0; i < articles.length; i++) {
                        const currArticle = articles[i];

                        if(currArticle.category === "JavaScript"){
                            JSArticles.push(currArticle);
                        }
                        else if (currArticle.category === "C#") {
                            CSharpArticles.push(currArticle);
                        }
                        else if(currArticle.category === "Java") {
                            JavaArticles.push(currArticle);
                        }
                        else if(currArticle.category === "Python") {
                            PythonArticles.push(currArticle);
                        }
                        
                    }

                    ctx.JSArticles = JSArticles;
                    ctx.CSharpArticles = CSharpArticles;
                    ctx.JavaArticles = JavaArticles;
                    ctx.PythonArticles = PythonArticles;

                    this.loadPartials(getPartials())
                        .partial("../views/home.hbs");
                })
                .catch(console.error);
        } else {
            this.loadPartials(getPartials())
                .partial("../views/auth/login.hbs");
        }
      });
  
      this.get("#/register", function (ctx) {
        this.loadPartials(getPartials())
            .partial("../views/auth/register.hbs");
    });

    this.post("#/register", function (ctx) {
        const {
            email,
            password,
            reppass
        } = ctx.params;

        if (email && password && password === reppass) {
            post("user", "", {
                username : email,
                email,
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
            email,
            password
        } = ctx.params;

        if (email && password) {
            post("user", "login", {
                username : email,
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
            .partial("../views/article/create.hbs");
    });

    this.post("#/create", function (ctx) {
        const {
            title,
            category,
            content
        } = ctx.params;

        let email = sessionStorage.getItem("username");

        if (title && category && content) {
            post("appdata", "articles", {
                title,
                category,
                content,
                creator : email
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

        get("appdata", `articles/${id}`, "Kinvey")
            .then((article) => {
                ctx.isCreator = sessionStorage.getItem("username") === article.creator;
                ctx.article = article;

                this.loadPartials(getPartials())
                    .partial("../views/article/details.hbs");
            })
            .catch(console.error);
    });

    this.get("#/delete/:id", function(ctx){
        const id = ctx.params.id;
        setHeaderInfo(ctx);

        del("appdata", `articles/${id}`, "Kinvey")
        .then(()=>{
            ctx.redirect("#/home");
        })
        .catch(console.error);
    });

    this.get("#/edit/:id", function (ctx) {
        const id = ctx.params.id;
        setHeaderInfo(ctx);

        get("appdata", `articles/${id}`, "Kinvey")
            .then((article) => {
                ctx.article = article;

                this.loadPartials(getPartials())
                    .partial("../views/article/edit.hbs");
            })
            .catch(console.error);
    });

    this.post("#/edit/:id", function (ctx) {
        const id = ctx.params.id;
        setHeaderInfo(ctx);

        const {
            title,
            category,
            content,
        } = ctx.params;

        let creator = sessionStorage.getItem("username");

        put("appdata", `articles/${id}`, {
            title,
            category,
            content,
            creator
            },
                "Kinvey")
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
        sessionStorage.setItem("email", `${userInfo.email}`);
        sessionStorage.setItem("userId", userInfo._id);
    }

    function setHeaderInfo(ctx) {
        ctx.isAuth = sessionStorage.getItem("authtoken") !== null;
        ctx.username = sessionStorage.getItem("username");
        ctx.email = sessionStorage.getItem("email");
    }

    });
    app.run('#/home');
  })();