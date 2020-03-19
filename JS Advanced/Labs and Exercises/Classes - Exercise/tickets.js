function solve(inputArr, criteria){
    class Ticket {
        constructor(destination, price, status) {
            this.destination = destination;
            this.price = price;
            this.status = status;
        }
    }

    let allTickets = [];

    for (let i = 0; i < inputArr.length; i++) {
        let currData = inputArr[i];
        let [destination, price, status] = currData.split("|");
        price = Number(price);
        let ticket = new Ticket(destination, price, status);
        allTickets.push(ticket);
    }

    if(criteria === "price"){
        return allTickets.sort((a,b) => a-b);
    }
    else{
        return allTickets.sort((a,b) => a[criteria].localeCompare(b[criteria]));
    }
}