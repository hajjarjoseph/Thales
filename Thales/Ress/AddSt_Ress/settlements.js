onload = function(){
    var x = 10; //number of Appartments
    
    for(var j = 1; j<=x; j++){

        var father = document.getElementById("accordion");
        var card = document.createElement("div");
            card.className ="card card-plain";
        var cardHeader = document.createElement("div");
            cardHeader.className = "card-header";
            cardHeader.setAttribute =("role","tab");
            cardHeader.setAttribute =("id","heading"+j);
        var a = document.createElement("a");
            a.setAttribute("data-toggle","collapse");
            a.setAttribute("data-parent","#accordion");
            a.setAttribute("href","#collapse"+j); 
            a.setAttribute("aria-expanded","true");
            a.setAttribute("aria-controls","collapse"+j); 
        var apptNum =document.createTextNode('Appt '+j+":");
        a.appendChild(apptNum);
        var icon = document.createElement("i");
            icon.className ="nc-icon nc-minimal-down";
        a.appendChild(icon);
        cardHeader.appendChild(a);
        card.appendChild(cardHeader);
        var collapse = document.createElement("div");
            collapse.id="collapse"+j; //change
            collapse.className = "collapse";
            collapse.setAttribute("role","tabpanel");
            collapse.setAttribute("aria-labelledby","heading"+j); 
        var cardBody = document.createElement("div");
            cardBody.className ="card-body docDown";
        var form = document.createElement("form");
        var table = document.createElement("table");
            table.className ="table";
            table.id = "appTable";
        var tr = document.createElement("tr");
        var td = document.createElement("td");
        var td1 = document.createElement("td");
        var td2 = document.createElement("td");
        var td3 = document.createElement("td");
        var add = document.createTextNode("+");
        td.appendChild(add);
        var inpAdd = document.createElement("input");
            inpAdd.id = "add";
            inpAdd.setAttribute("type","text");
            inpAdd.value="0";
            inpAdd.className = "appInput ";
            inpAdd.className += "form-control";
        td.appendChild(inpAdd);
        tr.appendChild(td);
        var sub = document.createTextNode("-");
        td1.appendChild(sub);
        var inpSub = document.createElement("input");
            inpSub.id = "sub";
            inpSub.setAttribute("type","text");
            inpSub.value="0";
            inpSub.className = "appInput ";
            inpSub.className += "form-control";
        td1.appendChild(inpSub);
        tr.appendChild(td1);
        var balance = document.createTextNode("Owes: $"+200); //put balance here
        td2.appendChild(balance);
        tr.appendChild(td2);
        var button = document.createElement("button");
        button.className = "btn btn-danger";
        button.innerHTML ="submit";
        td3.appendChild(button);
        tr.appendChild(td3);
        table.appendChild(tr);
        form.appendChild(table);
        cardBody.appendChild(form);
        collapse.appendChild(cardBody);
        card.appendChild(collapse);
        father.appendChild(card);
    }     
}
