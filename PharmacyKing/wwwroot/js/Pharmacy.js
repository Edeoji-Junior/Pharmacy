$(document).ready(function () {
	$("#countryList").change(function () {
		$("#stateList").empty();
		var id = $("#countryList").val();
		$.ajax({
			type: 'GET',
			url: '/Account/LoadState',
			data: { id: id },
			success: function (states) {
				$.each(states, function (i, state) {
					$("#stateList").append('<option value="' + state.id + ' ">' + state.name + '</option>');
				});
			},
			Error: function (ex) {
				alert('Failed to retreive state .' + ex);
			}
		});

	})
});

function registerUser()
{
	debugger;
	var data = {};
	data.Email = $("#email").val();
	data.Password = $("#password").val();
	data.ConfirmPassword = $("#comfirmpassword").val();
	if (data.Email != "" && data.Password != "" && data.ConfirmPassword != "") {
		let userToBeCreatedData = JSON.stringify(data);
		if (userToBeCreatedData != "") {
			$.ajax({
				type: 'Post',
				url: '/Account/AddUsers', 
				dataType: 'json',
				data:
				{
					applicationUserViewModel: userToBeCreatedData
				},
				success: function (result) {
					debugger;
					if (!result.isError) {
						var url = '/Account/Login/';
						successAlertWithRedirect(result.msg, url)
					}
					else {
						errorAlert(result.msg)
					}
				},
				error: function (ex) {
					debugger;
					errorAlert("Network failure, please try again");
				}

			});
		}
		else {
			errorAlert("Input cannot be Empty, Please filling yuor Details!.");
		}
	}
};

function SignIn(){
	debugger;
	var data = {};
	data.Email = $("#email").val();
	data.Password = $("#password").val();
	if (data.Email != "" && data.Password != "")
	{
		var logindetails = JSON.stringify(data);
		$.ajax({
			type: "POST",
			dataType: "Json",
			url: "/Account/Login",
			data: { loginViewModel: logindetails },
			success: function (result) {
				debugger;
				if (!result.isError) {
					var url = '/Admin/Index';
					successAlertWithRedirect(result.msg, url);
				}
				else {
					errorAlert(result.msg)
				}
			},
			error: function (ex) {
				debugger;
				errorAlert("Network failure, please try again");
			}
		});
	}
	else
	{
		errorAlert("Input cannot be Empty, Please filling yuor Details!.");
	}
};

function editRoles(Id) {
	debugger
	let data = Id;
	$.ajax({
		type: 'GET',
		url: '/Admin/EditRole', // we are calling json method
		dataType: 'json',
		data:
		{
			edeitRoleId: Id
		},
		success: function (data) {
			debugger
			if (!data.isError) {
				$('#editRoleId').val(Id);
				$('#editRoleName').val(data.name);
			}
		},
		error: function (ex) {
			"Something went wrong, contact support - " + errorAlert(ex);
		}
	});
};

function saveEditedRole()
{
	debugger
	var data = {};
	data.Id = $("#editRoleId").val();
	data.Name = $("#editRoleName").val();
	if (data.Name != "")
	{
		let saveEditedRole = JSON.stringify(data);
		if (saveEditedRole !="")
		{
			$.ajax({
				type: 'Post',
				url: '/Admin/AddSaveRole',
				dataType: 'json',
				data:
				{
					saveEditedRole: saveEditedRole
				},
				success: function (result) {
					debugger;
					if (!result.isError) {
						var url = '/Admin/Index/';
						successAlertWithRedirect(result.msg, url)
					}
					else {
						errorAlert(result.msg)
					}
				},
				error: function (ex) {
					debugger;
					errorAlert("Network failure, please try again");
				}

			});
        }
    }
	else
	{
		errorAlert("Input cannot be Empty, Please filling yuor Details!.");
	}
}