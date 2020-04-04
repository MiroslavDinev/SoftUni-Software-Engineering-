const username = "guest";
const password = "guest";
const appKey = "kid_S1p6Ads4I";

const headers = {
    method:"GET",
    headers:{
        "Authorization": `Basic ${btoa(`${username}:${password}`)}`,
        "content-type" : "application/json"
    }
};

let tableBody = document.getElementById("tbody");

(()=>{

    listStudents();

    async function listStudents(){
        let allStudents = await fetch(`https://baas.kinvey.com/appdata/${appKey}/students`,headers)
        .then(res=>{
            if(!res.ok) {
                throw new Error(res.statusText);
            }

            return res;
        })
        .then(data=>data.json())
        .catch(err=>alert(err));

        allStudents.sort((a,b)=>a.ID-b.ID);

        for (let i = 0; i < allStudents.length; i++) {
            let currStudent = allStudents[i];
            let tr = document.createElement("tr");
            let IdTd = document.createElement("td");
            IdTd.textContent = currStudent.ID;

            let firstNameTd= document.createElement("td");
            firstNameTd.textContent = currStudent.FirstName;

            let lastNameTd = document.createElement("td");
            lastNameTd.textContent = currStudent.LastName;

            let facultyNumberTd = document.createElement("td");
            facultyNumberTd.textContent = currStudent.FacultyNumber;

            let gradeTd = document.createElement("td");
            gradeTd.textContent = `${currStudent.Grade.toFixed(2)}`;

            tr.append(IdTd,firstNameTd,lastNameTd,facultyNumberTd,gradeTd);
            tableBody.appendChild(tr);
        }
    }
})();