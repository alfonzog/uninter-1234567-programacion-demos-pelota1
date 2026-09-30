namespace Pelota1
{
  public partial class Form1 : Form
  {

    // Posición de la pelota
    float pelotaX = 100;
    float pelotaY = 50;

    // Velocidad
    float velocidadX = 3;
    float velocidadY = 0;

    // Gravedad
    float gravedad = 0.5f;

    // Tamaño de la pelota
    int diametro = 50;


    public Form1()
    {
      InitializeComponent();
    }

    private void Form1_Paint(object sender, PaintEventArgs e)
    {
      Graphics g = e.Graphics;

      // Dibujar el piso
      using (Pen lapiz = new Pen(Color.Black, 3))
      {
        g.DrawLine(
            lapiz,
            0,
            this.ClientSize.Height - 1,
            this.ClientSize.Width,
            this.ClientSize.Height - 1
        );
      }

      // Dibujar pelota
      using (SolidBrush pincel = new SolidBrush(Color.Red))
      {
        g.FillEllipse(
            pincel,
            pelotaX,
            pelotaY,
            diametro,
            diametro
        );
      }

      // Borde de la pelota
      using (Pen lapizPelota = new Pen(Color.DarkRed, 2))
      {
        g.DrawEllipse(
            lapizPelota,
            pelotaX,
            pelotaY,
            diametro,
            diametro
        );
      }
    }

    private void timer1_Tick(object sender, EventArgs e)
    {
      // Aplicar gravedad
      velocidadY += gravedad;

      // Mover pelota
      pelotaX += velocidadX;
      pelotaY += velocidadY;

      // Rebote contra el piso
      if (pelotaY + diametro >= this.ClientSize.Height)
      {
        pelotaY = this.ClientSize.Height - diametro;

        // Invertir velocidad vertical
        velocidadY = -velocidadY;

        // Pérdida de energía
        velocidadY *= 0.85f;
      }

      // Rebote contra la pared derecha
      if (pelotaX + diametro >= this.ClientSize.Width)
      {
        pelotaX = this.ClientSize.Width - diametro;
        velocidadX = -velocidadX;
      }

      // Rebote contra la pared izquierda
      if (pelotaX <= 0)
      {
        pelotaX = 0;
        velocidadX = -velocidadX;
      }

      // Redibujar el formulario
      this.Invalidate();
    }

    private void Form1_Load(object sender, EventArgs e)
    {

    }

    private void button1_Click(object sender, EventArgs e)
    {
      timer1.Start();
    }

    private void button2_Click(object sender, EventArgs e)
    {
      timer1.Stop();
    }
  }
}
