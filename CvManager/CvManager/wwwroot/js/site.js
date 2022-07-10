// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

const loginContainer = document.getElementById('loginContainer');

if (window.location.pathname == "/Identity/Account/Login" || window.location.pathname == "/Identity/Account/Register") {
    loginContainer.style.display = "none";
}

if (window.location.pathname == "/Identity/Account/Logout") {
    window.location.href = "/"
}

if (window.location.pathname == "/Cv") {
    document.querySelector('main').style = "width:100%"
    document.querySelector('.jsStyle').classList.add('container')
    document.querySelector('.jsStyle').style = ""
}


  

    const table = document.getElementById('ExpTable');
    const rows = table.getElementsByTagName('tr');


    const calcTotalYears = () => {
        const yearsInput = document.getElementById("TotalExperience");
        const totalYears = document.getElementsByClassName("yearsWorked");
        let totalExperience = 0;

        for (let year of totalYears) {
            totalExperience += eval(year.value)
        }
        yearsInput.value = totalExperience;
        return;
    }
    document.addEventListener("change", e => {
        e.target.classList.contains('yearsWorked') && calcTotalYears();
    });

    const DeleteItem = btn => {
        if (rows.length == 2) {
            alert("Nie można usunąć")
            return;
        }


        const btnIndex = btn.id.replaceAll('btnRemove-', '');
        const idOfDeleted = btnIndex + '__IsDeleted';


        const hiddenIsDeleted = document.querySelector("[id$='" + idOfDeleted + "']").id;

        document.getElementById(hiddenIsDeleted).value = "true";

        $(btn).closest('tr').hide();
        calcTotalYears();

    }



    const AddItem = () => {
        const lastRowIndex = rows.length - 2;

        let rowOuterHtml = rows[rows.length - 1].outerHTML;


        const nextRowIndex = eval(lastRowIndex) + 1;


        rowOuterHtml = rowOuterHtml.replaceAll('_' + lastRowIndex + '_', '_' + nextRowIndex + '_');
        rowOuterHtml = rowOuterHtml.replaceAll('[' + lastRowIndex + ']', '[' + nextRowIndex + ']');
        rowOuterHtml = rowOuterHtml.replaceAll('-' + lastRowIndex, '-' + nextRowIndex);


        let newRow = table.insertRow();
        newRow.innerHTML = rowOuterHtml;

        const inputs = document.getElementsByTagName("input");

        for (let input of inputs) {
            if ((input.type == "text" || input.type == "number") && input.id.indexOf('_' + nextRowIndex + '_') > 0)
                input.value = '';

        }


        rebindValidators();

    }

    const rebindValidators = () => {
        const $form = $("#ApplicantForm");


        $form.unbind();
        $form.data("validator", null);

        $.validator.unobtrusive.parse($form);
        $form.validate($form.data("unobtrusiveValidation").options);
    }


