

$(document).ready(function () {
    class User{
        constructor(fullname, email, phone, gender, birthDay,id) {
            this.FullName = fullname;
            this.Email = email;
            this.Phone = phone;
            this.Gender = parseInt(gender);
            this.Birthday = new Date(birthDay);
            this.Id = id;
        }
    }
    
    $("#BtnRegister").click(function (e) {
        if (check_required_inputs()) {

            var user = new User($("#fullname").val(), $("#email").val(), $("#phone").val(), $("#gender option:selected").val(), $("#birthDay").val(),0);
            $.ajax({
                type: 'post',
                url: '/api/User',
                data: JSON.stringify(user),
                contentType: 'application/json; charset=utf-8',
                dataType: "json",
                success: function (res) {
                    
                    alert(GetMessage(res));
                    if (res == 1)
                          window.location.href = 'UserListPage.html';
                },
                error: function (res) {
                    alert(res);
                }
            });
        }
        function GetMessage(res) {
            switch (res) {
                case -1: return "This email already exists"
                case 0: return "Error"
                case 1: return "User created successfully"
            }
        }
        
     
      
      
    });

    
        
});
  
function check_required_inputs() {

    var isValid = true;
    var req = $('.required');
    for (var i = 0; i < req.length; i++) {
        if ($(req[i]).val() == "") {
            $(req[i]).addClass('Required-Red');
            isValid = false;
           
        }
        else
            $(req[i]).removeClass('Required-Red');
    }
    if (!isValid)
        alert('Please Insert All Required Fields');
    return isValid;
 
}
