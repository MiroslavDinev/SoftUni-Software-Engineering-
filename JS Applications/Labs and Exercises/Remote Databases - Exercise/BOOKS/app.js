const username = "guest";
const password = "guest";

const appKey = "kid_S1p6Ads4I";
const appSecret = "f05fc635974c4f2abd00a92febd9d071";

const baseUrl = `https://baas.kinvey.com/appdata/${appKey}/books`;

function makeHeaders(httpMethod, data){
    let headers = {
        method: httpMethod,
        headers:{
            "Authorization" : `Basic ${btoa(`${username}:${password}`)}`,
            "content-type" : "application/json"
        }
    };

    if(httpMethod === "POST" || httpMethod === "PUT") {
        headers.body = JSON.stringify(data);
    }

    return headers;
}

const htmlElements = {
    "loadBooks":()=> document.getElementById("loadBooks"),
    "allBooksTable" : ()=> document.getElementById("allBooksTable"),
    "title": ()=> document.getElementById("title"),
    "author": ()=> document.getElementById("author"),
    "isbn": ()=> document.getElementById("isbn"),
    "editForm": ()=>document.getElementById("editForm"),
    "edit-title" :()=> document.getElementById("edit-title"),
    "edit-author":()=> document.getElementById("edit-author"),
    "edit-isbn": ()=> document.getElementById("edit-isbn"),
    "submit-edit":()=> document.getElementById("submit-edit")
};

function loadBooks(){
    let booksTable = htmlElements.allBooksTable();
    booksTable.innerHTML = "";
    let headers = makeHeaders("GET");
    fetch(baseUrl,headers)
    .then(res=>{
        if(!res.ok) {
            throw new Error(res.statusText);
        }

        return res;
    })
    .then(data=>data.json())
    .then(books=>books.forEach(currBook => {
        let bookId = currBook._id;
        let title = currBook.Title;
        let author = currBook.Author;
        let isbn = currBook.ISBN;

        let tr = document.createElement("tr");
        tr.setAttribute("id", bookId);

        let titleTd = document.createElement("td");
        titleTd.textContent = title;

        let authorTd = document.createElement("td");
        authorTd.textContent = author;

        let isbnTd = document.createElement("td");
        isbnTd.textContent = isbn;

        let buttonsTd = document.createElement("td");

        let editBtn = document.createElement("button");
        editBtn.textContent = "Edit";

        let deleteBtn = document.createElement("button");
        deleteBtn.textContent = "Delete";

        buttonsTd.append(editBtn,deleteBtn);

        tr.append(titleTd,authorTd,isbnTd,buttonsTd);
        booksTable.appendChild(tr);
    }))
    .catch(err=>alert(err));  
}

function createBook(){
    let bookTitle = htmlElements.title().value;
    let bookAuthor = htmlElements.author().value;
    let bookIsbn = htmlElements.isbn().value;

    if(bookTitle && bookAuthor && bookIsbn) {
        let data = {
            "Title" : bookTitle,
            "Author": bookAuthor,
            "ISBN" : bookIsbn
        };

        let headers = makeHeaders("POST",data);

        fetch(baseUrl,headers)
        .then(res=>{
            if(!res.ok){
                throw new Error(res.statusText);
            }

            return res;
        })
        .then(loadBooks())
        .catch(err=>alert(err));

        htmlElements.title().value = "";
        htmlElements.author().value = "";
        htmlElements.isbn().value = "";
    }
}

function deleteBook(e){
    let parentTd = e.parentNode.parentNode;
    let idToDelete = parentTd.id;
    let booksTable = htmlElements.allBooksTable();

    const url = `${baseUrl}/${idToDelete}`;
    let headers = makeHeaders("DELETE");

    fetch(url,headers)
    .then(res=>{
        if(!res.ok){
            throw new Error(res.statusText);
        }

        return res;
    })
    .then(booksTable.removeChild(parentTd))
    .catch(err=>alert(err));
}

function editBookGet(e){
    let parentTd = e.parentNode.parentNode;
    let idToEdit = parentTd.id;

    let editForm = htmlElements.editForm();
    editForm.style.display = "";

    htmlElements["edit-title"]().setAttribute("bookId",idToEdit);
    htmlElements["edit-title"]().value = parentTd.children[0].textContent;
    htmlElements["edit-author"]().value = parentTd.children[1].textContent;
    htmlElements["edit-isbn"]().value = parentTd.children[2].textContent;
}

function editBookPost(e){
    let parentTd = e.parentNode;
    let idToEdit = parentTd.children[2].getAttribute("bookId");

    let editedTitle = parentTd.children[2].value;
    let editedAuthor = parentTd.children[4].value;
    let editedIsbn = parentTd.children[6].value;

    let data = {
        "Title": editedTitle,
        "Author": editedAuthor,
        "ISBN": editedIsbn
    };

    const url = `${baseUrl}/${idToEdit}`;
    let headers = makeHeaders("PUT",data);

    fetch(url,headers)
    .then(res=>{
        if(!res.ok){
            throw new Error(res.statusText);
        }

        return res;
    })
    .then(parentTd.style.display="none")
    .then(loadBooks())
    .catch(err=>alert(err));
}

function handleEvent(e) {
    if(e.target.id === "loadBooks"){
        loadBooks();
    }
    else if(e.target.id === "submit"){
        e.preventDefault();
        createBook();
    }
    else if(e.target.textContent==="Delete"){
        deleteBook(e.target);
    }
    else if (e.target.textContent === "Edit"){
        editBookGet(e.target);
    }
    else if(e.target.id === "submit-edit"){
        e.preventDefault();
        editBookPost(e.target);
    }
}

(function(){
    document.body.addEventListener("click",handleEvent);
}());