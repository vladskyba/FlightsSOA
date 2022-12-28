<template>
    <section class="container">
    <button id="show-modal" class="btn btn-dark righter" @click="student">Створити Студента</button>
    <button id="show-modal" class="btn btn-dark righter" @click="teacher">Створити Викладача</button>
    <button id="show-modal" class="btn btn-dark" @click="logout">Вийти</button>

  </section>
</template>

<script>
import Modal from '@/components/Modal.vue'
export default {
  name: 'DashboardPage',
  components: {
    Modal
  },
  data() {
    return {
      showModal: false,
      message: "it it some mine message"
    }
  },
  methods: {
    logout(){
      localStorage.clear();
      this.$router.push('/login');
    },
    flight(){
      this.$router.push('/flight');
    },
    teacher(){
      this.$router.push('/teacher');
    }
  }
}
</script>

<style scoped>
  .righter{
    margin-right: 20px;
  }
</style>