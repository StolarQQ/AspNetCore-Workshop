﻿
class MeasurementListSection{

    addNewMeasurement(measurement) {

        let grid = document.querySelector("#measurements_container");
        let newRow = grid.children[1].cloneNode(true);
        grid.appendChild(newRow);

        let idColumn = newRow.querySelector('div[data-column-type=\'id\']');
        let nameColumn = newRow.querySelector('div[data-column-type=\'name\']');
        let valueColumn = newRow.querySelector('div[data-column-type=\'value\']');
        let createdByColumn = newRow.querySelector('div[data-column-type=\'createdBy\']');
        let removeBtn = newRow.querySelector('a[data-action=\'remove\']');

        removeBtn.addEventListener('click', e => {
            let idColumn = newRow.querySelector('div[data-column-type=\'id\']');
            this.
            removeBtn.parentElement.parentElement.remove();
            //newRow.remove();
        });

        idColumn.innerHTML = measurement.id;
        nameColumn.innerHTML = measurement.name;
        valueColumn.innerHTML = measurement.value;

        newRow.classList.remove('d-none');
        grid.appendChild(newRow);
    }

}
