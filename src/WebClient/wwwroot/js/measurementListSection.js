
class MeasurementListSection{

    _listeners = []

    addNewMeasurement(measurement) {

        let grid = document.querySelector("#measurements_container");
        let newRow = grid.children[1].cloneNode(true);
        grid.appendChild(newRow);

        let idColumn = newRow.querySelector('div[data-column-type=\'id\']');
        let nameColumn = newRow.querySelector('div[data-column-type=\'name\']');
        let valueColumn = newRow.querySelector('div[data-column-type=\'value\']');
        let createdByColumn = newRow.querySelector('div[data-column-type=\'createdBy\']');
        let createdAtColumn = newRow.querySelector('div[data-column-type=\'createdAt\']')

        let removeBtn = newRow.querySelector('a[data-action=\'remove\']');
        
        removeBtn.addEventListener('click', e => {
            let idColumn = removeBtn.parentElement.parentElement.querySelector("div[data-column-type=\'id\']")
            removeBtn.parentElement.parentElement.remove();

            this._raiseMeasurementRemovedEvent({
                id: idColumn.innerText
            })

            //newRow.remove();
        });

        idColumn.innerHTML = measurement.id;
        nameColumn.innerHTML = measurement.name;
        valueColumn.innerHTML = measurement.value;
        createdByColumn.innerHTML = measurement.createdBy;
        createdAtColumn.innerText = measurement.createdAt;

        newRow.classList.remove('d-none');
        grid.appendChild(newRow);
    }

    addEventListener(listener) {
        this._listeners.push(listener);
    }

    _raiseMeasurementRemovedEvent(e) {
        this._listeners.forEach(i => {
            i.measurementRemoved(e)
        })
    }

}
