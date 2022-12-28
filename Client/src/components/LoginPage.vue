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
            <div class="bg-white text-left moved">
                <form @submit.prevent="pagelogin">
                    <p>Введіть інформацію для входу</p>
                    
                    <div class="form-group">
                        <label for="login" class="input-label"></label>
                        <input type="text" class="form-control" placeholder="Логін" v-model="credentials.login">
                    </div>
                    <div class="form-group">
                        <label for="password" class="input-label"></label>
                        <input type="password" class="form-control" placeholder="Пароль" v-model="credentials.password">
                    </div>
                    <div class="form-group">
                        <input type="submit" value="Увійти" class="btn btn-dark w-100 mt-lg-2" />
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
  name: 'LoginPage',
  components: {
    Modal
  },
  data(){
    return{
        credentials:{
            login: null,
            password: null
        },
        modalMessage: null,
        showModal: false
    }
  },
  methods: {
    async pagelogin() {
        try {
            var isValid = true;

                if(this.credentials.password == null || this.credentials.password == ''){
                isValid = false
                this.modalMessage = "Пароль обов'язковий для входу!"
                this.showModal = true; 
            }

            if(this.credentials.login == null || this.credentials.login == ''){
                isValid = false;
                this.modalMessage = "Логін обов'язковий для входу!"
                this.showModal = true; 
            }
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

.btn:focus {
  box-shadow: none;
}
</style>