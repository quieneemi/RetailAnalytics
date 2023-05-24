const PROXY_CONFIG = [
  {
    context: ["/api"],
    target: "http://localhost:5272",
    secure: false
  }
];

module.exports = PROXY_CONFIG;
