import java.awt.EventQueue;
import javax.swing.*;
import javax.swing.border.EmptyBorder;
import java.awt.Font;
import java.awt.Color;
import java.io.IOException;
import java.util.Scanner;

public class GUI extends JFrame {
    private JPanel contentPane; //content
    private static JTextField numOfGuards; //first input- Number of guards
    private JTextField dayLength; //second input- The length of the election day

    static Scanner sc = new Scanner(System.in);

    public static void main(String[] args) {
        EventQueue.invokeLater(new Runnable() {
            public void run() {
                try {
                    GUI frame = new GUI(); //create
                    frame.setVisible(true);

                } catch (Exception e) {
                    e.printStackTrace();
                }
            }
        });
    }

    //Create the frame
    public GUI() {
        setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
        setBounds(100, 100, 450, 300);
        contentPane = new JPanel();
        contentPane.setBorder(new EmptyBorder(5, 5, 5, 5));
        setContentPane(contentPane);
        contentPane.setLayout(null);

        //Create the start button
        JButton btnStart = new JButton("Start");
        btnStart.addActionListener(e -> {

            int num = CheckInput();
            double length = setdayLength();
            if (num != 0)
                Start(num, length);
        });

        //Start button design
        btnStart.setFont(new Font("Ariel", Font.BOLD | Font.ITALIC, 18));
        btnStart.setBounds(114, 163, 89, 31);
        btnStart.setForeground(Color.BLUE);
        contentPane.add(btnStart);

        JButton btnExit = new JButton("Exit");
        btnExit.addActionListener(e -> System.exit(0));

        //Exit button design
        btnExit.setFont(new Font("Ariel", Font.BOLD | Font.ITALIC, 18));
        btnExit.setBounds(247, 163, 89, 31);
        btnExit.setForeground(Color.RED);
        contentPane.add(btnExit);

        //The main title
        JLabel lblNewLabel = new JLabel("Welcome to kalfi Beer-sheva election system!");
        lblNewLabel.setFont(new Font("Impact", Font.PLAIN, 18));
        lblNewLabel.setBounds(10, 26, 426, 31);
        lblNewLabel.setForeground(new Color(128, 0, 128));
        contentPane.add(lblNewLabel);

        //The explanation of what the user should write
        JLabel num_of_guards = new JLabel("Security guard number:");
        num_of_guards.setFont(new Font("Ariel", Font.PLAIN, 14));
        num_of_guards.setBounds(45, 77, 350, 24);
        contentPane.add(num_of_guards);

        JLabel day_length = new JLabel("Closing kalfi time:");
        day_length.setFont(new Font("Ariel", Font.PLAIN, 14));
        day_length.setBounds(45, 112, 350, 19);
        contentPane.add(day_length);

        numOfGuards = new JTextField();
        numOfGuards.setFont(new Font("Ariel", Font.PLAIN, 14));
        numOfGuards.setText("1");
        numOfGuards.setBackground(new Color(255, 255, 255));
        numOfGuards.setBounds(260, 79, 32, 20);
        contentPane.add(numOfGuards);
        numOfGuards.setColumns(10);

        dayLength = new JTextField();
        dayLength.setFont(new Font("Ariel", Font.PLAIN, 14));
        dayLength.setText("8");
        dayLength.setBounds(260, 111, 32, 20);
        contentPane.add(dayLength);
        dayLength.setColumns(10);
    }

    //Check if input of number of guard is valid, if not set to default
    private int CheckInput() {
        setdayLength();
        int NumOfGuards = 1; //default
        boolean validinput = true;
        String stringNumOfGuards = numOfGuards.getText();

        if (!stringNumOfGuards.matches("\\d+")) { //check if its integer
            validinput = false;
            JOptionPane.showMessageDialog(null, "Invalid input. Please insert new number. Choose integer number between 1 to 4", "Error", JOptionPane.ERROR_MESSAGE);
        } else {
            NumOfGuards = Integer.parseInt(stringNumOfGuards);
            if (NumOfGuards < 1 || NumOfGuards > 4) { //vaild input
                JOptionPane.showMessageDialog(null, "Please insert new number. Choose integer number between 1 to 4", "Error", JOptionPane.ERROR_MESSAGE);
                validinput = false;
            }
        }
        if (validinput)
            return NumOfGuards;
        return 0;
    }

    //Check if input of day length is valid, if not set to default
    private double setdayLength() {
        double DayLength = 8;
        String stringDayLength = dayLength.getText();
        if (stringDayLength.matches("\\d+(\\.\\d+)?")) { //check if its integer number
            DayLength = Double.parseDouble(stringDayLength);
            if (DayLength < 0) {
                System.out.println("You choose time shorter than 0, the day length will be 0 ");
                DayLength = 0;
            }
            if (DayLength > 24) {
                System.out.println("You choose time longer than 24, the day length will be 24 ");
                DayLength = 24;
            }
        }
        return DayLength;
    }

    public void Start(int numOfGuards, double dayLength) {

        try {
            //Files
            String id_list = "src\\id list (assignment 4).txt";
            String voters_data = "src\\voters data (assignment 4).txt";

            //Starting election day!
            Election E = new Election(numOfGuards, dayLength);
            E.StartElection(voters_data, id_list);

        } catch (IOException ioe) {
            ioe.printStackTrace();
        }

    }

} //endClass

