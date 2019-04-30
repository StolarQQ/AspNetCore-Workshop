class MeasurementController {

    constructor() {
        this._newMeasurementSection = new NewMeasurementSection();
        this._newMeasurementListSection = new MeasurementListSection();

        let _this = this;

        this._newMeasurementSection.addEventListener(new class {
            newMeasurementAdded(e) {
                _this._newMeasurementListSection.addNewMeasurement(e);
            }
        });
    }
}

(() => new MeasurementController())();