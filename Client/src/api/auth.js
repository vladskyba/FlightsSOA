export default function(instance) {
    return {
        login(l, p){
            return instance.post('user/login', null, 
            { params: {
                login: l,
                password: p
            }})
        }
    }
}