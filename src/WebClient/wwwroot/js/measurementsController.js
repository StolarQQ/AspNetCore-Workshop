class MeasurementController {

    _service = null;
    _serviceUrl = '';
    constructor() {

        this._serviceUrl = new MeasurementService('https://localhost:44343/');
        this._newMeasurementSection = new NewMeasurementSection();
        this._newMeasurementListSection = new MeasurementListSection();

        let _this = this;

        this._newMeasurementSection.addEventListener(new class {
            newMeasurementAdded(e) {

                let data = e;
                e.createdBy = 'Operator';
                e.createdAt = '2019-04-15T09:11:40.0190';
                _this._service.post(e);
                
            }
        });

        this._service.addEventListener(new class {
            getResponseBody(e) {

                JSON.parse(e.data).forEach(i => {
                    _this._newMeasurementListSection.addNewMeasurement({
                        id: i.id,
                        name: i.name,
                        value: i.value,
                        createdBy: i.createdBy
                    });
                });
            }

            postResponseBody(e) {
                _this._newMeasurementListSection.addNewMeasurement(Json.parse(e.data));
            }
        });
    }
}


(() => new MeasurementController())();