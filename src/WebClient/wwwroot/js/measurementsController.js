class MeasurementController {

    _service = null;
    _serviceUrl = '';

    constructor() {

        this._service = new MeasurementService('http://localhost:49856/');
        this._newMeasurementSection = new NewMeasurementSection();
        this._newMeasurementListSection = new MeasurementListSection();

        let _this = this;

        this._newMeasurementSection.addEventListener(new class {
            newMeasurementAdded(e) {

                let data = {};

                data.name = e.name;
                data.value = e.value;
                data.createdBy = 'Operator';
                data.createdAt = (new Date()).toISOString();
                _this._service.post(data);
            }
        });

        this._newMeasurementListSection.addEventListener(new class {
         
            measurementRemoved(e) {
                _this._service.delete(e.id);
            }
        })

        this._service.addEventListener(new class {
            getResponseReady(e) {
                JSON.parse(e.data).forEach(i => {
                    _this._newMeasurementListSection.addNewMeasurement({
                        id: i.id,
                        name: i.name,
                        value: i.value,
                        createdBy: i.createdBy,
                        createdAt: i.createdAt
                    });
                });
            }

            postResponseReady(e) {
                _this._newMeasurementListSection.addNewMeasurement(JSON.parse(e.data));
            }

            deleteResponseReady(e) {
             
            }
        });

        this._service.get();
    }
}

(() => new MeasurementController())();