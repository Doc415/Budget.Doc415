function deleteCategory(id) {

    fetch(`/Category/Delete/${id}`, {
        method: 'POST'
    }).then(response => {
        window.location.href = `/Transaction/Index`;
    })
}