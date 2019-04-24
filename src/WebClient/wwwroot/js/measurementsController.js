
class MeasurmentController {

    constructor() {
        this._newMeasurementSection = new NewMeasurmentSection();
        this._newMeasurementListSection = new MeasurementListSection();
        let _this = this;


        this._newMeasurementSection.addEventListener(new class {
            NewMeasurementAdded(e) {
                _this._newMeasurementSection.addEventListener(e);
            }
        });

        }

}



(() => new MeasurmentController())();   