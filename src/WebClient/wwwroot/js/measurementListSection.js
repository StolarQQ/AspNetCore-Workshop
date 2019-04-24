
class MeasurementListSection{


    addNewMesurement(measurement) {

        let grid = document.querySelector("#mesurements_container");
        let newRow = grid.children[i].cloneNode(true);
        grid.appendChild(newRow);

        let nameColumn = newRow.querySelector('div[data-column-type=\'name\']');
        let valueColumn = newRow.querySelector('div[data-column-type=\'value\']');
        let removeBtn = newRow.querySelector('a[data-action=\'remove\']');

        removeBtn.addEventListener('click', e => {
            removeBtn.parentElement.parentElement.remove();
            //newRow.remove();
        });

        nameColumn.innerHTML = measurement.name;
        valueColumn.innerHTML = measuement.value;

        newRow.classList.remove('d-none');
        grid.appendChild(newRow);
    }

}
