class Company {
    constructor() {
        this.departments = [];
    }

    addEmployee(username, salary, position, department) {
        if (!username || !salary || !position || !department) {
            throw new Error("Invalid input!");
        }

        if (salary < 0) {
            throw new Error("Invalid input!");
        }

        let foundDept = this.departments.find(x => x.name === department);

        if (!foundDept) {
            foundDept = {
                name: department,
                employees: [],
                averageSalary: function () {
                    let sumOfAllSalaries = 0;
                    for (let i = 0; i < this.employees.length; i++) {
                        let currEmployee = this.employees[i];
                        sumOfAllSalaries += currEmployee.salary;
                    }

                    return sumOfAllSalaries / this.employees.length;
                }
            };

            this.departments.push(foundDept);
        }

        let newEmployee = {
            username,
            salary,
            position
        };

        foundDept.employees.push(newEmployee);

        return `New employee is hired. Name: ${username}. Position: ${position}`;
    }

    bestDepartment() {
        let bestDept = this.departments.sort((a, b) => b.salary - a.salary)[0];

        let result = `Best Department is: ${bestDept.name}\n`;
        result += `Average salary: ${bestDept.averageSalary().toFixed(2)}\n`;
        let sortedEmployees = bestDept.employees.sort((a, b) => b.salary - a.salary || a.username.localeCompare(b.username));
        for (let i = 0; i < sortedEmployees.length; i++) {
            let currEmployee = sortedEmployees[i];
            result += `${currEmployee.username} ${currEmployee.salary} ${currEmployee.position}\n`;
        }

        return result.trim();
    }
}

let c = new Company();
c.addEmployee("Stanimir", 2000, "engineer", "Construction");
c.addEmployee("Pesho", 1500, "electrical engineer", "Construction");
c.addEmployee("Slavi", 500, "dyer", "Construction");
c.addEmployee("Stan", 2000, "architect", "Construction");
c.addEmployee("Stanimir", 1200, "digital marketing manager", "Marketing");
c.addEmployee("Pesho", 1000, "graphical designer", "Marketing");
c.addEmployee("Gosho", 1350, "HR", "Human resources");
console.log(c.bestDepartment());