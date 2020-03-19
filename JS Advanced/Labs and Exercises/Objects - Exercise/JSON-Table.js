function solve(arr){
    let result = "";
    result += "<table>\n";
    for(let entry of arr){
      let obj = JSON.parse(entry);
      let keys = Object.keys(obj);
      result += "	<tr>\n";
      for(let key of keys){
        result += `		<td>${obj[key]}</td>\n`;
      }
      result += "	</tr>\n";
    }
    result += "</table>";
    console.log(result);
  }

  solve(['{"name":"Pesho","position":"Promenliva","salary":100000}',
  '{"name":"Teo","position":"Lecturer","salary":1000}',
  '{"name":"Georgi","position":"Lecturer","salary":1000}']
  );