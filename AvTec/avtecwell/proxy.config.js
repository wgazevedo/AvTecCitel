const proxy = [
    {
      context: '/api',
      target: 'http://localhost:53186',
      pathRewrite: {'^/api' : ''}
    }
  ];
  module.exports = proxy;