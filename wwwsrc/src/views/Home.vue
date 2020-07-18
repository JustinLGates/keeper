<template>
  <div class="home">
    <div class="card-columns">
      <Keep v-for="keep in publicKeeps" :key="keep.id" :keep="keep" />
      <div type="button" data-toggle="modal" data-target="#keepFormModal">click me</div>
    </div>
  </div>
</template>

<script>
import Keep from "../components/Keep";
export default {
  name: "home",
  mounted() {
    this.$store.dispatch("getPublicKeeps");
  },
  computed: {
    user() {
      return this.$store.state.user;
    },
    publicKeeps() {
      return this.$store.state.KeepsStore.publicKeeps;
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
