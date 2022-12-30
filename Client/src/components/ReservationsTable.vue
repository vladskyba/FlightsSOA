<template>
<table class="table table-bordered">
  <thead>
    <tr>
      <th scope="col">#</th>
      <th scope="col">Status</th>
      <th scope="col">Departure</th>
      <th scope="col">Arrival</th>
      <th scope="col">Cost</th>
    </tr>
  </thead>
  <tbody>
    <tr v-for="(i, idx) of reservations" :key="i.id">
      <th> {{ idx + 1 }}</th>
      <td> {{ i.status }}</td>
      <td> {{ i.flight.departureAirport.name }} <br> {{ i.flight.departureTime }}</td>
      <td> {{ i.flight.arrivalAirport.name }} <br> {{ i.flight.arrivalTime }}</td>
      <td> {{ i.flight.cost }} USD</td>
    </tr>
  </tbody>
</table>
</template>

<script>
export default {
  props: {
    reservations: {
      required: true,
      type: Array
    }
  }
}
</script>
