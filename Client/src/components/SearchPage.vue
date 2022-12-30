<template>

  <div class="container">
    <form @submit.prevent="searchFlightss">
          <div class="row">
              <div class="col-4">Departure</div>
              <div class="col-4">Arrival</div>
              <div class="col-2">Departure Start</div>
              <div class="col-2">Departure End</div>
          </div>

          <div class="row">
              <div class="col-4">
                  <Select2 v-model="searchFilters.departureAirportId" :options="this.airports" :settings=" {width: '100%' }" />
              </div>
              <div class="col-4">
                  <Select2 v-model="searchFilters.arrivalAirportId" :options="this.airports" :settings=" {width: '100%' }" />
              </div>
              <div class="col-2">
                  <input type="datetime-local" class="form-control" v-model="searchFilters.startArrival">
              </div>
              <div class="col-2">
                  <input type="datetime-local" class="form-control" v-model="searchFilters.endArrival">
              </div>
          </div>

          <input type="submit" value="Search" class="btn btn-dark w-100 mt-lg-2 mt-0" />
    </form>
  </div>

  <section class="container" v-if="flights.length > 0">
    <SearchTable :flights="flights" />
  </section>

</template>

<script>
import Modal from './Modal.vue';
import SearchTable from './SearchTable.vue';

export default {
  name: 'FlightsSearch',
  components: {
    Modal,
    SearchTable
  },
  
  data(){
    return{
        searchFilters:{
            departureAirportId: null,
            arrivalAirportId: null,
            startDeparture: null,
            endDeparture: null
        },
        airports: [],
        flights: []
    }
  },
  created(){
    this.$load(async() => {
        this.airports = (await this.$api.airport.getAll()).data.map( item =>
        ( { id: item.id, text: [item.name, item.airportAddress.country, item.airportAddress.city].join(', ') } ));
    })
  },
  methods: {
    async searchFlightss() {        
        const searchedFlights = (await this.$api.flight.searchFlights(
          {
            departureAirportId: parseInt(this.searchFilters.departureAirportId),
            arrivalAirportId: parseInt(this.searchFilters.arrivalAirportId)
          }
        )).data;

        this.flights = searchedFlights.map(record => {
          return { 
            ...record
          }
        });
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