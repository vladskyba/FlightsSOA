<template>
    <section class="container">
    <Teleport to="body">
      <modal :show="showModal" @close="showModal = false">
        <template #header>
          <h3>{{modalMessage}}</h3>
        </template>
      </modal>
    </Teleport>
    <div class="row justify-content-center">
        <div class="col-lg-4">
            <div class="bg-white text-left">
                <p1>Створити авіарейс</p1>
                <form @submit.prevent="createFlight">
                    <div class="form-group">
                        <p class="bottomn">Виберіть літак</p>
                       <Select2 v-model="information.airplaneId" :options="this.airplanes" :settings=" {width: '100%' }" />
                    </div>
                    <div class="form-group">
                        <p class="bottomn">Виберіть аеропорт вильоту</p>
                       <Select2 v-model="information.departureAirportId" :options="this.airports" :settings=" {width: '100%' }" />
                    </div>
                    <div class="form-group">
                        <p class="bottomn">Виберіть аеропорт призначення</p>
                       <Select2 v-model="information.arrivalAirportId" :options="this.airports" :settings=" {width: '100%' }" />
                    </div>
                    <div class="form-group">
                        <label for="departureTime" class="input-label"></label>
                        <input type="datetime-local" class="form-control" placeholder="Час вильоту" v-model="information.departureTime">
                    </div>
                    <div class="form-group">
                        <label for="arrivalTime" class="input-label"></label>
                        <input type="datetime-local" class="form-control" placeholder="Час приземлення" v-model="information.arrivalTime">
                    </div>
                    <div class="form-group">
                        <label for="cost" class="input-label"></label>
                        <input type="text" class="form-control" placeholder="Ціна рейсу" v-model="information.cost">
                    </div>
                    <div class="form-group">
                        <input type="submit" value="Створити авіарейс" class="btn btn-dark w-100 mt-lg-2" />
                        <router-link to="/dashboard" class="btn btn-dark w-100 mt-lg-2" >Перейти до DashBoard</router-link>
                    </div>
                </form>
            </div>
        </div>
    </div>
  </section>
</template>

<script>
import Modal from './Modal.vue';

export default {
  name: 'Flight',
  components: {
    Modal
  },
  
  data(){
    return{
        information:{
            departureAirportId: null,
            departureTime : null,
            arrivalAirportId: null,
            arrivalTime : null,
            airplaneId: null,
            cost: null
        },
        airports: [],
        airplanes: [],
        modalMessage: null,
        showModal: false
    }
  },
  created(){
    this.$load(async() => {
        this.airports = (await this.$api.airport.getAll()).data.map( item =>
        ( { id: item.id, text: [item.name, item.airportAddress.country, item.airportAddress.city].join(', ') } ));
        
        this.airplanes = (await this.$api.airplane.getAll()).data.map( item => ( { id: item.id, text: item.name } ));
    })
  },
  methods: {
    async createFlight() {
        try {
            console.log(this.information)

            const data = (await this.$api.flight.createFlight({
                departureAirportId: parseInt(this.information.departureAirportId),
                departureTime: this.information.departureTime,
                arrivalAirportId: parseInt(this.information.arrivalAirportId),
                arrivalTime: this.information.arrivalTime,
                airplaneId: parseInt(this.information.airplaneId),
                cost : parseFloat(this.information.cost)
            })).data

            this.modalMessage = "Рейс успішно створено!"
            this.showModal = true;

            this.information.departureAirportId = null;
            this.information.departureTime = null;
            this.information.arrivalAirportId = null;
            this.information.arrivalTime = null;
            this.information.airplaneId = null;
            this.information.cost = null;
        }catch(error) {
            this.modalMessage = error.response.data
            this.showModal = true;
        }
    }
  },
}
</script>

<style>
.form-control:focus {
  box-shadow: none;
  border: 2px solid black;
}

.moved {
    padding-top: 30%;
}

.bottomn{
    margin-top: 12px;
}

.btn:focus {
  box-shadow: none;
}
</style>