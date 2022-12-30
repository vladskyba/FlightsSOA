export default function(instance) {
    return {
        createFlight(payload){
            return instance.post('/createFlight', payload)
        },
        searchFlights(payload){
            return instance.post('/searchFlights', payload)
        }
    }
}