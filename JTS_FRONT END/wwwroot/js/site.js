
const uri = 'https://localhost:44367/api/Users';
let users = [];

function getUsers() {
    /*fetch(uri)
        .then(response => response.json())
        .then(data => _displayItems(data))
        .catch(error => console.error('Unable to get items.', error));*/
    $.ajax({
        type: "GET",
        url: uri,
        success: function (response) {
            console.log(response)
            _displayUsers(response)
        },
        failure: function (response) {
            alert(response.d);
        }
    });
};

function AddUser() {
    AddForm = document.getElementById("AddUserForm");
    if (AddForm.role.value.trim() == "0") {
        rolevalue = 0;
    }
    else {
        rolevalue = 1;
    }
    if (AddForm.isActive.value.trim() == "on") {
        activevalue = true;
    }
    else {
        activevalue = false;
    }
    const user = {
        id:AddForm.id.value.trim(),
        username: AddForm.username.value.trim(),
        email: AddForm.email.value.trim(),
        firstName: AddForm.firstName.value.trim(),
        lastName: AddForm.lastName.value.trim(),
        contactNumber: AddForm.contactNumber.value.trim(),
        role: rolevalue,
        isActive: activevalue,
        dob: AddForm.dob.value.trim(),
        createdOn: AddForm.createdOn.value.trim()
    };

    fetch(uri, {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(user)
    })
        .then(respone => alert("User Added Successfully"))
        .then(() => {
            getUsers();
            AddForm.reset();
        })
        .catch(error => alert(error));

}

function _displayCount(userCount) {
    const name = (userCount === 1) ? 'User' : 'Users';

    document.getElementById('counter').innerText = `${userCount} ${name}`;
};

function deleteUser(id) {
    fetch(`${uri}/${id}`, {
        method: 'DELETE'
    })
        .then(() => getUsers())
        .catch(error => console.error('Unable to delete item.', error));
};

function displayAddUserForm() {
    console.log("AddUser");
    document.getElementById('AddUser').style.display = 'block';
}

function displayEditForm(id) {
    const user = users.find(u => u.id === id);
    document.getElementById('editUser-ID').value = user.id;
    document.getElementById('editUser-username').value = user.username;
    document.getElementById('editUser-email').value = user.email;
    document.getElementById('editUser-firstName').value = user.firstName;
    document.getElementById('editUser-lastName').value = user.lastName;
    document.getElementById('editUser-contactNumber').value = user.contactNumber;
    if (user.role == 0) {
        document.getElementById('editUser-role').value = "0";
    }
    else {
        document.getElementById('editUser-role').value = "1";
    }
    document.getElementById('editUser-isActive').checked = user.isActive;
    document.getElementById('editUser-dob').value = user.dob;
    document.getElementById('editUser-createdOn').value = user.createdOn;
    document.getElementById('EditUser').style.display = 'block';
}

function updateUser() {
    id = document.getElementById("editUser-ID").value.trim();
    if (document.getElementById("editUser-role").value.trim() == "0") {
        rolevalue = 0;
    }
    else {
        rolevalue = 1;
    }
    //if (document.getElementById("editUser-isActive").value.trim() == "on") {
    //    activevalue = true;
    //}
    //else {
    //    activevalue = false;
    //}
    const edituser = {
        id: document.getElementById("editUser-ID").value.trim(),
        username: document.getElementById("editUser-username").value.trim(),
        email: document.getElementById("editUser-email").value.trim(),
        firstName: document.getElementById("editUser-firstName").value.trim(),
        lastName: document.getElementById("editUser-lastName").value.trim(),
        contactNumber: document.getElementById("editUser-contactNumber").value.trim(),
        role: rolevalue,
        isActive: document.getElementById("editUser-isActive").checked,
        dob: document.getElementById("editUser-dob").value.trim(),
        createdOn: document.getElementById("editUser-createdOn").value.trim()
    };
    console.log(edituser)

    fetch(`${uri}/${id}`, {
        method: 'PUT',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(edituser)
    })
        .then(respone => alert("User Updated Successfully"))
        .then(() => {
            getUsers();
        })
        .catch(error => alert(error));
}

function closeInput() {
    document.getElementById('EditUser').style.display = 'none';
    document.getElementById('AddUser').style.display = 'none';
}

function _displayUsers(data) {
    const tBody = document.getElementById('users');
    tBody.innerHTML = '';

    _displayCount(data.length);

    const button = document.createElement('button');

    data.forEach(user => {
        let isActiveCheckbox = document.createElement('input');
        isActiveCheckbox.type = 'checkbox';
        isActiveCheckbox.disabled = true;
        isActiveCheckbox.checked = user.isActive;

        let editButton = button.cloneNode(false);
        editButton.innerText = 'Edit';
        editButton.setAttribute('onclick', `displayEditForm(${user.id})`);

        let deleteButton = button.cloneNode(false);
        deleteButton.innerText = 'Delete';
        deleteButton.setAttribute('onclick', `deleteUser(${user.id})`);

        let tr = tBody.insertRow();

        let td1 = tr.insertCell(0);
        td1.appendChild(document.createTextNode(user.id));

        let td2 = tr.insertCell(1);
        td2.appendChild(document.createTextNode(user.username));

        let td3 = tr.insertCell(2);
        td3.appendChild(document.createTextNode(user.email));

        let td4 = tr.insertCell(3);
        td4.appendChild(document.createTextNode(user.firstName));

        let td5 = tr.insertCell(4);
        td5.appendChild(document.createTextNode(user.lastName));

        let td6 = tr.insertCell(5);
        td6.appendChild(document.createTextNode(user.dob));

        let td7 = tr.insertCell(6);
        td7.appendChild(document.createTextNode(user.contactNumber));

        let td8 = tr.insertCell(7);
        td8.appendChild(document.createTextNode(user.role));

        let td9 = tr.insertCell(8);
        td9.appendChild(document.createTextNode(user.createdOn));

        let td10 = tr.insertCell(9);
        td10.appendChild(isActiveCheckbox);

        let td11 = tr.insertCell(10);
        td11.appendChild(editButton);
        td11.appendChild(deleteButton);

    });

    users = data;
}