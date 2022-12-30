<template>

  <p1>Резервування користувача Rambls</p1>

  <section class="container" v-if="reservations.length > 0">
    <Table :reservations="reservations" />
  </section>

</template>

<script>
import Modal from './Modal.vue';
import Table from './ReservationsTable.vue';

export default {
  name: 'FlightsSearch',
  components: {
    Modal,
    Table
  },
  
  data(){
    return{
        reservations: []
    }
  },
  created(){
    this.$load(async() => {

        const searchedReservations = (await this.$api.reservation.getByUser(1)).data;

        console.log(searchedReservations);
        this.reservations = searchedReservations.map(record => { return { ...record }});
    })
  }
}
</script>