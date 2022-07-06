function CallWebAPI() { 
    var name = document.getElementById("txtName").value;
    var person = '{Name: "' + name + '" }';
    var request;
    if (window.XMLHttpRequest) {
        //New browsers.
        request = new XMLHttpRequest();
    }
    elseif(window.ActiveXObject) {
        //Old IE Browsers.
        request = new ActiveXObject("Microsoft.XMLHTTP");
    }
    if (request != null) {
        var url = "/api/AjaxAPI/AjaxMethod";
        request.open("POST", url, false);
        request.setRequestHeader("Content-Type", "application/json");
        request.onreadystatechange = function () {
            if (request.readyState == 4 && request.status == 200) {
                var response = JSON.parse(request.responseText);
                alert("Hello: " + response.Name + ".\nCurrent Date and Time: " + response.DateTime);
            }
        };
        request.send(person);
    }
}