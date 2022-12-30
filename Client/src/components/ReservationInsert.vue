<template>
    <section class="container">
    <div class="row justify-content-center">
        <div class="col-lg-8">
            <div class="bg-white text-left">
                <p1>Зробити резервування на рейс #1</p1> <br/>
                <p1>Користувач: {{ userName }}</p1>
                <form @submit.prevent="createReservation">
                    <div class="form-group">
                        <input type="text" class="form-control" placeholder="Email" v-model="reservation.email">
                        
                    <p1>Квиток</p1>
                    <div class="row">
                      <div class="col-4">
                          <input type="text" placeholder="Ім'я" class="form-control" v-model="ticket.personName">
                      </div>
                      <div class="col-4">
                          <input type="text" placeholder="Прізвище" class="form-control" v-model="ticket.personSurname">
                      </div>
                      <div class="col-4">
                          <input type="text" placeholder="По-батькові" class="form-control" v-model="ticket.personLastName">
                      </div>
                      <div class="col">
                          <input type="text" placeholder="Номер документу" class="form-control" v-model="ticket.documentIdentifier">
                      </div>
                    </div>  
                      <input type="submit" value="Зарезервувати квиток" class="btn btn-dark w-100 mt-lg-2" />
                    </div>
                </form>

            </div>
        </div>
    </div>
  </section>
</template>

<script>
import Modal from './Modal.vue';
import {useRoute} from "vue-router";

export default {
  name: 'ReservationInsert',
  components: {
    Modal
  },
  
  data(){
    return{
        reservation:{
            flightId: null,
            userId : 1,
            email : null,
            tickets : Array
        },
        ticket: {
          personName : null,
          personSurname : null,
          personLastName : null,
          documentIdentifier : null
        },
        userName: "Rambls"
    }
  },
  created(){
    const route = useRoute();
  },
  methods: {
    async createReservation() {
      
      this.reservation.tickets.push(this.ticket);
      await this.$api.reservation.createReservation({
          flightId: 1,
          email: this.reservation.email,
          userId: parseInt(this.reservation.userId),
          tickets : this.reservation.tickets
      })
    }
  }
}
</script>