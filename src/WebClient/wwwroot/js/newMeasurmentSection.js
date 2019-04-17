class NewMeasurmentSection {

    _listeners = []

    constructor() {
        let addBtn = document.querySelector('#measurment_addBtn')
        addBtn.addEventListener('click', x => {
            let nameInput = document.querySelector('#measurment_nameInput')
            let valueInput = document.querySelector('#measurment_valueInput')
            let obj = {
                name: nameInput.value,
                value: valueInput.value
            }
            this._raiseNewMeasurmentAdded(obj)            
        })

    }

    addEventListener(listener) {
        this._listeners.push(listener)
    }

    _raiseNewMeasurmentAdded(e) {
        this._listeners.forEach(l => {
            l.NewMeasurmentAdded(e)
        })
    }
}