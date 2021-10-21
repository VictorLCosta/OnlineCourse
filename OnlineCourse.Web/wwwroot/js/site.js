function formDomainException(error) {
    if(error.status == 500)
        error.responseJSON.forEach(function (errorMessage) {
            toastr.error(errorMessage)
        })
}