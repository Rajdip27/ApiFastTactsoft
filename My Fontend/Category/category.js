const category = () => {
    const tbody = document.getElementById("tbody")

    const url = "https://localhost:44391/Category/GetAll";
    fetch(url).then(res => res.json()).then(data => {
        data.map((data, index) => {
            tbody.innerHTML += `
        <tr>
        <td>${index + 1}</td>
        <td>${data.categoryName}</td>
        <td><button class="btn btn-danger" id="btn" onclick="deleteCategory(${data.categoryId})" >Delete</button></td>
        </tr>
        `;
        });
        document.querySelector('#myTable').appendChild(tbody);
    });
}
category();

const addCategory = () => {
    var form = document.getElementById('categoryFrom');
    form.addEventListener('submit', function (e) {
        e.preventDefault();
        var categoryName = document.getElementById('categoryName').value;
        fetch('https://localhost:44391/Category/Create', {
            method: 'POST',
            body: JSON.stringify({
                categoryName: categoryName
            }),
            headers: {
                'Content-type': 'application/json; charset=UTF-8',
            }
        }).then(res => res.json()).then(data => {
            window.location.reload()
        });
    });
}
addCategory();

const deleteCategory = (id) => {
    console.log(id);
    fetch(`https://localhost:44391/Category/Delete/${id}`, {
        method: 'DELETE',
    })
        .then(res => {
            window.alert("Data deleted Success")
            window.location.reload()
     })
}
