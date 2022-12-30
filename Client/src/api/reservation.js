export default function(instance) {
    return {
        createReservation(payload){
            return instance.post('/create', payload)
        },
        getByUser(id){
            return instance.get('/getByUser', { params: { userId: id }})
        }
    }
}