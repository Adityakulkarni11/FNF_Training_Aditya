let isSignIn = true;

document.addEventListener('DOMContentLoaded', () => {
  submitButton.addEventListener('click', handleSubmit);
  toggleLink.addEventListener('click', toggleForm);
  signOutAllBtn.addEventListener('click', signOutAll);
  updateActiveUsers();
});

function toggleForm() {
  isSignIn = !isSignIn;
  formTitle.textContent = isSignIn ? 'Sign In' : 'Sign Up';
  submitButton.textContent = isSignIn ? 'Sign In' : 'Sign Up';
  toggleText.innerHTML = isSignIn
    ? "Don't have an account? <span id='toggle-link'>Sign Up</span>"
    : "Already have an account? <span id='toggle-link'>Sign In</span>";
  message.textContent = '';
  error.textContent = '';
  window.toggleLink = document.getElementById('toggle-link');
  toggleLink.addEventListener('click', toggleForm);
}

function updateActiveUsers() {
  const activeUsers = JSON.parse(localStorage.getItem('activeUsers') || '[]');
  userList.innerHTML = '';
  activeUsers.forEach(email => {
    const li = document.createElement('li');
    li.textContent = email;
    userList.appendChild(li);
  });
}

function handleSubmit() {
  const email = emailInput.value.trim();
  const password = passwordInput.value.trim();
  message.textContent = '';
  error.textContent = '';

  if (!email || !password) {
    error.textContent = 'Please fill in both fields.';
    return;
  }

  let users = JSON.parse(localStorage.getItem('users') || '{}');
  let activeUsers = JSON.parse(localStorage.getItem('activeUsers') || '[]');

  if (isSignIn) {
    if (users[email] && users[email].password === password) {
      message.textContent = 'Login successful!';
      if (!activeUsers.includes(email)) {
        activeUsers.push(email);
        localStorage.setItem('activeUsers', JSON.stringify(activeUsers));
      }
    } else {
      error.textContent = 'Invalid credentials.';
    }
  } else {
    if (users[email]) {
      error.textContent = 'Email already registered.';
    } else {
      users[email] = { password: password };
      localStorage.setItem('users', JSON.stringify(users));
      message.textContent = 'Sign up successful! You can now sign in.';
      toggleForm();
    }
  }

  updateActiveUsers();
}

function signOutAll() {
  localStorage.setItem('activeUsers', JSON.stringify([]));
  updateActiveUsers();
}
