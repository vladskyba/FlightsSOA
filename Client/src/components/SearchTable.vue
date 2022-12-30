<template>
<table class="table table-bordered">
  <thead>
    <tr>
      <th scope="col">#</th>
      <th scope="col"></th>
      <th scope="col">Departure</th>
      <th scope="col">Arrival</th>
      <th scope="col">Cost</th>
    </tr>
  </thead>
  <tbody>
    <tr v-for="(i, idx) of flights" :key="i.id">
      <th> {{ idx + 1 }}</th>
      <th> 
        <button type="submit" @click="$router.push('/createReservation/' + i.id)" class="btn btn-dark w-100 mt-lg-2 mt-0">
          Make a reservation
        </button>
      </th>
      <td> {{ [i.departureAirport.name + i.arrivalTime].join(', ') }}</td>
      <td> {{ [i.arrivalAirport.name, i.departureTime].join(', ')  }}</td>
      <td> {{ i.cost  }} USD</td>
    </tr>
  </tbody>
</table>
</template>

<script>
export default {
  props: {
    flights: {
      required: true,
      type: Array
    }
  }
}
</script>