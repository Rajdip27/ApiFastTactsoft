const category = () => {
    const tbody = document.getElementById("tbody")

    const url = "https://localhost:44391/Category";
    fetch(url).then(res => res.json()).then(data => {
        data.map((data, index) => {
            tbody.innerHTML += `
        <tr>
        <td>${index + 1}</td>
        <td>${data.categoryName}</td>
        <td><button class="btn btn-success" id="btn" onclick="getCatagopryById(${data.categoryId})" >Edit</button> | <button class="btn btn-danger" id="btn" onclick="deleteCategory(${data.categoryId})" >Delete</button></td>
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
        fetch('https://localhost:44391/Category', {
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


const updateCatagoray = (id) => {
    var form = document.getElementById('categoryFrom');
    form.addEventListener('submit', function (e) {
        e.preventDefault();
        var categoryName = document.getElementById('categoryName').value;
        fetch(`https://localhost:44391/Category/id:int?id=${id}`, {

            method: 'PUT',
            body: JSON.stringify({
                categoryId: id,
                categoryName: categoryName
            }),
            headers: {
                'Content-type': 'application/json; charset=UTF-8',
            }
        }).then(res => res.json()).then(data => {
            debugger;
            window.location.reload()
        });
    });
}

const deleteCategory = (id) => {
    console.log(id);
    fetch(`https://localhost:44391/Category/id:int?id=${id}`, {
        method: 'DELETE',
    })
        .then(res => {
            window.alert("Data deleted Success")
            window.location.reload()
        })
}
const getCatagopryById = (id) => {
    console.log(id);
    let myTextbox = document.getElementById('categoryName');
    fetch(`https://localhost:44391/Category/id:int?id=${id}`)
        .then(res => {
            if (!res.ok) {
                throw new Error('Network response was not ok');
            }
            return res.json();
        })
        .then(data => {
            myTextbox.value = data.categoryName;
            updateCatagoray(data.categoryId)
        })
        .catch(error => {
            console.error('Fetch error:', error);

        });
};
