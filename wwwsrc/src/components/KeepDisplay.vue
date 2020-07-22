<template>
  <div class="home container-fluid">
    <div class="row">
      <div class="col-12 pt-3">
        <div class="card-columns">
          <Keep v-for="keep in publicKeeps" :key="keep.Id" :keepData="keep" />
        </div>
      </div>
    </div>
  </div>
</template>

<script>
import Keep from "../components/Keep";
export default {
  name: "home",
  mounted() {
    this.$store.dispatch("getAllUserKeeps");
  },
  computed: {
    user() {
      return this.$store.state.user;
    },
    publicKeeps() {
      return this.$store.state.KeepsStore.keeps;
    }
  },
  methods: {
    logout() {
      this.$store.dispatch("logout");
    }
  },
  components: {
    Keep
  }
};
</script>