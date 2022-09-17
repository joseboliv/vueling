
var account = (function () {

    function RegisterUser(data) {
        debug;
        if (!$("#AccountRegister").valid()) {
            return false;
        }
        postDialog("/account/Register", data);


    }

    return {
        RegisterUser: RegisterUser
    };
})();



//Chequea mejor este codigo

function Account() {
    this.Nombre;
    this.Apellido;
    this.Accion = () => {
        return `${this.Nombre} aqui retorna lo que requieres`;
    };
};

$(document).ready(function () {

    Account.Accion();//y borralo papa

});