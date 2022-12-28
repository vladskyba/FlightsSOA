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
                <p>Зареєструвати викладача</p>
                <form @submit.prevent="createTeacher">
                    <div class="form-group">
                        <label for="login" class="input-label"></label>
                        <input type="text" class="form-control" placeholder="Логін" v-model="information.login">
                    </div>
                    <div class="form-group">
                        <label for="password" class="input-label"></label>
                        <input type="password" class="form-control" placeholder="Пароль" v-model="information.password">
                    </div>
                    <div class="form-group">
                        <label for="lastName" class="input-label"></label>
                        <input type="text" class="form-control" placeholder="Прізвище" v-model="information.lastName">
                    </div>
                    <div class="form-group">
                        <label for="firstName" class="input-label"></label>
                        <input type="text" class="form-control" placeholder="Ім'я" v-model="information.firstName">
                    </div>
                    <div class="form-group">
                        <input type="submit" value="Зареєструвати викладача" class="btn btn-dark w-100 mt-lg-2" />
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
  name: 'Student',
  components: {
    Modal
  },
  data(){
    return{
        information:{
            login: null,
            password: null,
            firstName: null,
            lastName: null
        },
        modalMessage: null,
        showModal: false
    }
  },
  methods: {
    async createTeacher() {
        try {
            var isValid = true;

                if(this.information.password == null || this.information.password == ''){
                    isValid = false
                    this.modalMessage = "Пароль обов'язковий для реєстрації!"
                    this.showModal = true; 
                }

                if(this.information.login == null || this.information.login == ''){
                    isValid = false;
                    this.modalMessage = "Логін обов'язковий для реєстрації!"
                    this.showModal = true; 
                }

                if(this.information.lastName == null || this.information.lastName == ''){
                    isValid = false;
                    this.modalMessage = "Прізвище обов'язкове для реєстрації!"
                    this.showModal = true; 
                }

                if(this.information.firstName == null || this.information.firstName == ''){
                    isValid = false;
                    this.modalMessage = "Ім'я обов'язкове для реєстрації!"
                    this.showModal = true; 
                }

        if(isValid){
            console.log(this.information)

            console.log(this.$api.auth)

            const data = (await this.$api.teacher.register({
                login: this.information.login,
                password: this.information.password,
                firstName: this.information.firstName,
                lastName: this.information.lastName
            })).data
            this.information.login = null;
            this.information.password = null;
            this.information.firstName = null;
             this.information.lastName = null;

            this.modalMessage = "Викладача зареєстровано!"
            this.showModal = true;
        }
        }catch(error) {
            this.modalMessage = "Неможливо зареєструвати викладача. Щось пішло не так!"
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

.btn:focus {
  box-shadow: none;
}
</style>