onload = function(){
    setNumberOfBills();
    getHighestBills();
    getTotal();
}

function setNumberOfBills(){
    var numberofBills = document.getElementById("numberofBills");
    var tableBody = document.getElementById("billTableBody");
    var count = tableBody.rows.length -2 ;
    numberofBills.innerHTML = count;
}

function getHighestBills(){
    var max = 0  ;
    var tableBody = document.getElementById("billTableBody");
    for(var i = 1; i<tableBody.rows.length -1; i++){
        var tableCells = tableBody.rows.item(i).cells;
        var TableItem = tableCells.item(4).innerHTML;
       
        var price = TableItem.split(" ");
        
        
        if(parseInt(price[1]) > max){
            max = parseInt(price[1]);
        }
    }
    document.getElementById("mostExpensive").innerHTML="$ "+ max;
}
function getTotal(){
    var sum = 0  ;
    var tableBody = document.getElementById("billTableBody");
    for(var i = 1; i<tableBody.rows.length -1; i++){
        var tableCells = tableBody.rows.item(i).cells;
        var TableItem = tableCells.item(4).innerHTML;
       
        var price = TableItem.split(" ");
        sum += parseInt(price[1]);
    }
    document.getElementById("billTotal").innerHTML="$ "+ sum;
}
