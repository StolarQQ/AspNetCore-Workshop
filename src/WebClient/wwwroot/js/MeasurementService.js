class MeasurementService {

    _serviceUrl = "";
    _listener = []; 

    constructor(serviceUrl) {

        this._serviceUrl = serviceUrl + 'api/mesurement';
    }

    addEventListener(listener) {

        this._listener.push(listener);
    }

    get() {

        let req = new XMLHttpRequest()
        req.onreadystatechange = e => {

            if (req.readyState === 4 & req.status === 200) {
                this._raiseGetResponseBody({
                    data: req.response
                })
            }
        }

        req.open('GET', this._serviceUrl)
        req.send()
    }

    post(data) {

        let req = new XMLHttpRequest()
       
        req.onreadystatechange = e => {

            if (req.readyState === 4 & req.status === 201) {
                this._raisePostResponseBody({
                    data: req.response
                })
            }
        }

        req.open('POST', this._serviceUrl)
        req.setRequestHeader("Content-Type", "application/json");
        req.send(data)
    }

    _raiseGetResponseBody(e) {

        this._listener.forEach(l => {
            l.getResponseBody(e)
        })
    }

    _raisePostResponseBody(e) {

        this._listener.forEach(l => {
            l.postResponseBody(e)
        })
    }
}