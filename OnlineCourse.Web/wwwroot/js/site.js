function formDomainException(error) {
    if(error.status == 500)
        error.responseJSON.forEach(function (errorMessage) {
            toastr.error(errorMessage)
        })
}

function formDomainSuccess(data) {
    if(data.success === true) {
        toastr.success(data.message, "Alerta de sucesso")
    }
    else {
        toastr.error(data.message, "Alerta de Erro")
    }
}