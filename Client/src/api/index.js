import airplaneModule from './airplane'
import airportModule from './airport'
import flightModule from './flight'
import reservationModule from './reservation'
import axios from 'axios'

const airportInstance = axios.create({
    baseURL: 'http://localhost:6001',
    withCredentials: false,
    headers: {
      accept: 'application/json'  
    }
})

const airplaneInstance = axios.create({
  baseURL: 'http://localhost:6002',
  withCredentials: false,
  headers: {
    accept: 'application/json'  
  }
})

const flightInstance = axios.create({
  baseURL: 'http://localhost:6003',
  withCredentials: false,
  headers: {
    accept: 'application/json'  
  }
})

const reservationInstance = axios.create({
  baseURL: 'http://localhost:6004',
  withCredentials: false,
  headers: {
    accept: 'application/json'  
  }
})

export default{
    airplane: airplaneModule(airplaneInstance),
    airport : airportModule(airportInstance),
    flight : flightModule(flightInstance),
    reservation : reservationModule(reservationInstance)
}