// models/Promotion.js

const mongoose = require('mongoose');

const promotionSchema = new mongoose.Schema({
  title: {
    type: String,
    required: true, // Título de la promoción
  },
  description: {
    type: String,
    required: true, // Descripción de la promoción
  },
  discountPercentage: {
    type: Number,
    required: true, // Porcentaje de descuento
  },
  startDate: {
    type: Date,
    required: true, // Fecha de inicio de la promoción
  },
  endDate: {
    type: Date,
    required: true, // Fecha de finalización de la promoción
  },
  productId: {
    type: mongoose.Schema.Types.ObjectId,
    ref: 'Product', // Relación con el modelo de Producto
  },
}, {
  timestamps: true, // Añade createdAt y updatedAt
});

module.exports = mongoose.model('Promotion', promotionSchema);
