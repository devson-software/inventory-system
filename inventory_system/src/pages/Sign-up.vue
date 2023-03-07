
<template>
  <q-page>
    <q-form class="signup-form" @submit="handleSubmit">
      <h2 class="signup-title">Sign Up</h2>
      <q-input v-model="name" label="Name" outlined class="signup-input" />
      <q-input v-model="email" type="email" label="Email" outlined class="signup-input" />
      <q-input v-model="password" type="password" label="Password" outlined class="signup-input" />
      <q-btn type="submit" label="Sign up" class="signup-btn" />
    </q-form>
  </q-page>
</template>

<script>
export default {
  data() {
    return {
      name: '',
      email: '',
      password: '',
    };
  },
  methods: {
    handleSubmit() {
      // Handle form submission here
    },
  },
};
</script>