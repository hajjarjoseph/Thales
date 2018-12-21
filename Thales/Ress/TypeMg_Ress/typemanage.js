window.onload= function(){
    var select = document.getElementById("TypeSelect");
    select.onclick = tableCreate;
    var c = document.getElementById("clearButton");
    c.onclick = clearTable;
}
function tableCreate(){ //Populates Table onchange of select value
    var select = document.getElementById("TypeSelect");
    var table = document.getElementById("shareManage");
    table.innerHTML="";
    //get the next 2 vars from Database
    var numberOfAppartments = 4;
    var shares = 1000;
    if(select.value!=0 /**&& no data exists create new */){

        for(var i=1; i<= numberOfAppartments;i++){
            var tr =document.createElement('tr');
            var td = document.createElement('td');
            var td1 = document.createElement('td');
            var txt = document.createTextNode('Appt '+i+": ");
            td.appendChild(txt);
            var inp = document.createElement('input');
            inp.value = shares/ numberOfAppartments;
            inp.id = "appShare"+i;
            inp.className ="shareInp";
            inp.className+=" form-control";
            td1.appendChild(inp);
            tr.appendChild(td);
            tr.appendChild(td1);
            table.appendChild(tr);
        }
    }
// else if(select.value!=0 && data exists){
    // var tr =document.createElement('tr');
    // var td = document.createElement('td');
    // var td1 = document.createElement('td');
    // var txt = document.createTextNode('Appt '+i+": ");
    // td.appendChild(txt);
    // var inp = document.createElement('input');
    // inp.value = getValueFromDB;
    // inp.id = "appShare"+i;
    // inp.className ="shareInp";
    // inp.className+=" form-control";
    // td1.appendChild(inp);
    // tr.appendChild(td);
    // tr.appendChild(td1);
    // table.appendChild(tr);
// }

}

function clearTable(){  //clears table
    var table = document.getElementById("shareManage");
    table.innerHTML="";
    document.getElementById("TypeSelect").selectedIndex=0;
}