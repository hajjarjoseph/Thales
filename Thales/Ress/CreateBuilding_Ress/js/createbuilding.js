window.onload = function(){
    var select = document.getElementById("appSelect");
        for(var i =1; i<26; i++){   //populates Select element
            var opt = document.createElement('option');
            opt.value = i;
            opt.innerHTML = i;
            select.appendChild(opt);
        }
     document.getElementById('appButton').onclick = tablePop;  
     document.getElementById('shareInp').value = 1000; 
}

function tablePop(){    //populates table
    var select = document.getElementById("appSelect");
    var table = document.getElementById('appTable');
    var shares = document.getElementById('shareInp');
    var x = parseInt(shares.value);
    table.innerHTML =" ";
    for(var i=1; i<= select.value; i++){
        var tr = document.createElement('tr');
        var td1 = document.createElement('td');
        var txt = document.createTextNode('Appt '+i+": ");
        td1.appendChild(txt);
        var inp = document.createElement('input');
        inp.value = x/ parseInt(select.value);
        inp.id = "appShare"+i;
		inp.name = "appShare"+i;
        inp.className = "appInput ";
        inp.className += "form-control";
        tr.appendChild(td1);
        tr.appendChild(inp);
        table.appendChild(tr);
  
    }
}