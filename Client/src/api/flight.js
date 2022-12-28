export default function(instance) {
    return {
        createFlight(payload){
            return instance.post('/createFlight', payload)
        }
    }
}