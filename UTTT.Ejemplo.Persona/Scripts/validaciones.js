//True o false
window.addEventListener('load',validarFormulario);
const formulario = document.getElementById("form1");
const inputs = document.querySelectorAll('#form1 input');
const select = document.getElementById('ddlSexo');
//Regular exprexions 1
const expresiones = {
    correo: /^[a-zA-Z0-9.!#$%&'*+/=?^_`{|}~-]+@[a-zA-Z0-9-]+(?:\.[a-zA-Z0-9-]+)*$/  
};
const campos ={
    dropList: false,
    claveUnica: false,
    nombre: false,
    aPaterno: false,
    aMaterno: false,
    numHermanos: false,
    cElectronico: false,
    rfc: false,
    cp: false,
    fn: false
};
//Validacion de Campos
var validarFormulario = (e) =>{
    console.log(e.target.id);
   
    switch(e.target.id){
        case "txtClaveUnica":
            e.target.value = Numeros(e.target.value);
            if (e.target.value.length >= 4) {
            e.target.value = e.target.value.slice(0, 4);
            }
            if(e.target.value.length < 3 ){
                campos['claveUnica'] = false;
                document.getElementById("errcu").style.display = "block";
            }else{
                campos['claveUnica'] = true;
                document.getElementById("errcu").style.display = "none";
            }
        break;
        case "txtNombre":
            e.target.value = Letras(e.target.value);
            if (e.target.value.length >= 15 ) {
            e.target.value = e.target.value.slice(0, 15);
            }
        if(e.target.value.length < 3){
            campos['nombre']=false;
            document.getElementById("errname").style.display = "block";
        }else{
            campos['nombre']=false;
            document.getElementById("errname").style.display = "none";
        }
        break;
        case "txtAPaterno":
            e.target.value = Letras(e.target.value);
            if (e.target.value.length >= 15 ) {
            e.target.value = e.target.value.slice(0, 15);
            }
            if(e.target.value.length < 3){
                campos['aPaterno'] = false;
                document.getElementById("errpate").style.display = "block";
            }else{
                campos['aPaterno'] = true;
                document.getElementById("errpate").style.display = "none";
            }
        break;
        case "txtAMaterno":
            e.target.value = Letras(e.target.value);
            if (e.target.value.length >= 15 ) {
            e.target.value = e.target.value.slice(0, 15);
            }
            if(e.target.value.length < 3){
                campos['aMaterno'] = false;
                document.getElementById("errap").style.display = "block";
            }else{
                campos['aMaterno'] = true;
                document.getElementById("errap").style.display = "none";
            }
        break;
        case "numeroHermanos":
            e.target.value = Numeros(e.target.value);
            if (e.target.value.length >= 2 ) {
                e.target.value = e.target.value.slice(0, 2);
            }
            if(e.target.value.length < 1){
                campos['numHermanos'] = false;
                document.getElementById("errnh").style.display = "block";
            }else{
                campos['numHermanos'] = true;
                document.getElementById("errnh").style.display = "none";
            }
        break;
        case "correoElectronico":
            console.log(e.target.value);
            if(expresiones.correo.test(e.target.value)){
                campos['cElectronico'] = true;
                document.getElementById("errce").style.display = "none";
            }else{
                campos['cElectronico'] = false;
                document.getElementById("errce").style.display = "block";
            }
        break;
        case "rfc":
            e.target.value = NumerosLetras(e.target.value);
            if (e.target.value.length >= 13 ) {
            e.target.value = e.target.value.slice(0, 15);
            }
            if (e.target.value.length < 13 ) {
                campos['rfc'] = false;   
                document.getElementById("errrfc").style.display = "block";  
            }else{
                campos['rfc'] = true;
                document.getElementById("errrfc").style.display = "none";
            }
                
        break;
        case "codigoPostal":
            e.target.value = Numeros(e.target.value);
            if(e.target.value.length < 5){
                campos['cp'] = false;
                document.getElementById("errcp").style.display = "block";
            }else{
                campos['cp'] = true;
                document.getElementById("errcp").style.display = "none";
            }
        break;
        case "txtDobDat":
            console.log(e.target.value);
            ValidateDOB(e.target.value);
        break;
    }
}
var validarSelect = (e)=>{
    console.log(e.target.id);
    switch(e.target.id){
        case "ddlSexo":
            if(e.target.value == "-1"){
                campos['dropList']=false;
                document.getElementById("errge").style.display = "block";
            }else if(e.target.value == "1"){
                campos['dropList'] = true;
                document.getElementById("errge").style.display = "none";
            }
        break;
    }

}
//Validacion de fechas
function ValidateDOB(fecha) {
    //Get the date from the TextBox.

    var regex = /(((0|1)[0-9]|2[0-9]|3[0-1])\/(0[1-9]|1[0-2])\/((19|20)\d\d))$/;

    //Check whether valid dd/MM/yyyy Date Format.
    if (regex.test(fecha)) {
        var parts = fecha.split("/");
        var dtDOB = new Date(parts[1] + "/" + parts[0] + "/" + parts[2]);
        var dtCurrent = new Date();
        if (dtCurrent.getFullYear() - dtDOB.getFullYear() < 18) {
            document.getElementById("errfecha").style.display = "block";     

            return campos['fn'] = false;
        }

        if (dtCurrent.getFullYear() - dtDOB.getFullYear() == 18) {

            //CD: 11/06/2018 and DB: 15/07/2000. Will turned 18 on 15/07/2018.
            if (dtCurrent.getMonth() < dtDOB.getMonth()) {
                document.getElementById("errfecha").style.display = "block";    
                return campos['fn'] = false;
            }
            if (dtCurrent.getMonth() == dtDOB.getMonth()) {
                //CD: 11/06/2018 and DB: 15/06/2000. Will turned 18 on 15/06/2018.
                if (dtCurrent.getDate() < dtDOB.getDate()) {
                    document.getElementById("errfecha").style.display = "block";    
                    return campos['fn'] = false;
                }
            }
        }
        document.getElementById("errfecha").style.display = "none";    
        return campos['fn'] = true;
       
    } else {
        document.getElementById("errfecha").style.display = "block";    
        return campos['fn'] = false;
    }
}
//Validacion Genero

//Validacion al tecleo
inputs.forEach((input) =>{
    input.addEventListener('keyup',validarFormulario);
    input.addEventListener('blur',validarFormulario);
    
});
select.addEventListener('keyup',validarSelect);
select.addEventListener('blur',validarSelect);
//Funciones de Caracteres Letras o Numeros
function Letras(string) {//solo letras
    var out = '';
    //Se añaden las letras validas
    var filtro = 'abcdefghijklmnñopqrstuvwxyzABCDEFGHIJKLMNÑOPQRSTUVWXYZ';//Caracteres validos

    for (var i = 0; i < string.length; i++)
        if (filtro.indexOf(string.charAt(i)) != -1)
            out += string.charAt(i);
    return out;
}
function Numeros(string) {//Solo numeros
    var out = '';
    var filtro = '1234567890';//Caracteres validos

    //Recorrer el texto y verificar si el caracter se encuentra en la lista de validos 
    for (var i = 0; i < string.length; i++)
        if (filtro.indexOf(string.charAt(i)) != -1)
            //Se añaden a la salida los caracteres validos
            out += string.charAt(i);

    //Retornar valor filtrado
    return out;
} 
function NumerosLetras(string) {//Solo numeros
    var out = '';
    var filtro = '1234567890abcdefghijklmnñopqrstuvwxyzABCDEFGHIJKLMNÑOPQRSTUVWXYZ';//Caracteres validos

    //Recorrer el texto y verificar si el caracter se encuentra en la lista de validos 
    for (var i = 0; i < string.length; i++)
        if (filtro.indexOf(string.charAt(i)) != -1)
            //Se añaden a la salida los caracteres validos
            out += string.charAt(i);

    //Retornar valor filtrado
    return out;
} 
//Envio de datos
formulario.btnAceptar.addEventListener('click',(e)=>{
    
    if(select.value === "1" && campos.claveUnica && campos.nombre && campos.aPaterno && campos.aMaterno && campos.numHermanos && campos.cElectronico && campos.rfc && campos.rfc && campos.cp && campos.fn 
        ||
        select.value === "2"
        && formulario.txtClaveUnica.value.length >= 3 && formulario.txtNombre.value.length >= 3 && formulario.txtAPaterno.value.length >= 3 && formulario.txtAMaterno.value.length >= 3 && formulario.numeroHermanos.value.length >0  && formulario.rfc.value.length >= 13 && formulario.codigoPostal.value.length >= 5 && campos.fn){
        document.getElementById("warcampo").style.display = "none";
    }else{
        e.preventDefault();    
        document.getElementById("warcampo").style.display = "block";
    }
});

